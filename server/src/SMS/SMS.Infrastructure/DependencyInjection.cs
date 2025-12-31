using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using SMS.Core.Common;
using SMS.Core.Errors.Authentications;
using SMS.Core.Features.Channels;
using SMS.Core.Features.Posts;
using SMS.Core.Features.RefreshTokens;
using SMS.Core.Features.Teams;
using SMS.Core.Features.Users;
using SMS.Infrastructure.Authentication;
using SMS.Infrastructure.Database;
using SMS.Infrastructure.ExternalServices;
using SMS.Infrastructure.Options;
using SMS.Infrastructure.Queries.Countries;
using SMS.Infrastructure.Queries.Projects;
using SMS.Infrastructure.Queries.Tasks;
using SMS.Infrastructure.Queries.Workspaces;
using SMS.Infrastructure.Repositories;
using SMS.Infrastructure.WebStorages;
using SMS.UseCases.Abstractions.Authentication;
using SMS.UseCases.Abstractions.Data;
using SMS.UseCases.Abstractions.WebStorages;
using SMS.UseCases.Interfaces;
using SMS.UseCases.Queries.Countries;
using SMS.UseCases.Queries.Projects;
using SMS.UseCases.Queries.Tasks;
using SMS.UseCases.Queries.Workspaces;

namespace SMS.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services, IConfiguration configuration) =>
        services
            .AddDatabase(configuration)
            .AddRepositories()
            .AddAuthenticationInternal(configuration)
            .AddAuthorizationInternal()
            .AddWebStorages()
            .AddExternalServices()
            .AddApplicationOptions(configuration)
            .AddQueriesService();
    
    private static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        string? connectionString = configuration.GetConnectionString("DefaultConnection");

        services.AddScoped<IApplicationDbContext>(serviceProvider => serviceProvider.GetRequiredService<ApplicationDbContext>());
        
        services.AddScoped<IUnitOfWork>(serviceProvider => serviceProvider.GetRequiredService<ApplicationDbContext>());

        services.AddDbContext<ApplicationDbContext>(
            options => options.UseNpgsql(connectionString, npgsqlOptions => 
                    npgsqlOptions.MigrationsHistoryTable(HistoryRepository.DefaultTableName, Schemas.Default))
                .UseSnakeCaseNamingConvention());

        return services;
    }
    
    private static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services
            .AddScoped(typeof(IRepository<>), typeof(EfRepository<>))
            .AddScoped<ITeamRepository, TeamRepository>()
            .AddScoped<IChannelRepository, ChannelRepository>()
            .AddScoped<IPostRepository, PostRepository>()
            .AddScoped<IRefreshTokenRepository, RefreshTokenRepository>()
            
            .AddScoped<IUserRepository, UserRepository>();

        return services;
    }
    
    private static IServiceCollection AddAuthenticationInternal(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        var jsonOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };

        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(opt =>
        {
            opt.RequireHttpsMetadata = false;
            opt.TokenValidationParameters = new TokenValidationParameters
            {
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtOptions:AccessTokenKey"]!)),
                ValidIssuer = configuration["JwtOptions:Issuer"],
                ValidAudience = configuration["JwtOptions:Audience"],
                ClockSkew = TimeSpan.Zero
            };

            opt.Events = new JwtBearerEvents
            {
                OnChallenge = async context =>
                {
                    context.HandleResponse();

                    context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                    context.Response.ContentType = "application/json";

                    var payload = BaseResult.FailureResult(AuthenticationErrors.UnAuthorized);

                    await context.Response.WriteAsync(JsonSerializer.Serialize(payload, jsonOptions));

                },

                OnForbidden = async context =>
                {
                    context.Response.StatusCode = StatusCodes.Status403Forbidden;
                    context.Response.ContentType = "application/json";

                    var payload = BaseResult.FailureResult(AuthenticationErrors.UnAuthenticated);

                    await context.Response.WriteAsync(JsonSerializer.Serialize(payload, jsonOptions));
                }
            };
        });

        services.AddHttpContextAccessor();

        services
            .AddSingleton<IUserProvider, UserProvider>()
            .AddSingleton<ITokenProvider, TokenProvider>()
            .AddSingleton<IPasswordHasher, PasswordHasher>();

        return services;
    }

    private static IServiceCollection AddAuthorizationInternal(
        this IServiceCollection services)
    {
        services.AddAuthorization();

        return services;
    }
    
    private static IServiceCollection AddWebStorages(
        this IServiceCollection services)
    {
        services
            .AddScoped<ICookieService, CookieService>();

        return services;
    }
    
    private static IServiceCollection AddQueriesService(this IServiceCollection services)
    {
        services
            .AddScoped<IGetCountriesService, GetCountriesService>()
            
            .AddScoped<IGetProjectByIdAndLockService, GetProjectByIdAndLockService>()
            
            .AddScoped<IGetRoleByNameService, GetRoleByNameService>()
            .AddScoped<IGetMembersByWorkspaceIdService, GetMembersByWorkspaceIdService>()
            .AddScoped<IGetWorkspacesService, GetWorkspacesService>()
            .AddScoped<IGetWorkspaceMemberByWorkspaceIdAndUserIdService, GetWorkspaceMemberByWorkspaceIdAndUserIdService>()
            .AddScoped<IGetTasksByWorkspaceIdService, GetTasksByWorkspaceIdService>()
            
            .AddScoped<IGetMenuViewsByRoleIdService, GetMenuViewsByRoleIdService>()
            .AddScoped<IGetProjectsByWorkspaceIdService, GetProjectsByWorkspaceIdService>()
            .AddScoped<IVerifyExistedProjectCodeByWorkspaceIdService, VerifyExistedProjectCodeByWorkspaceIdService>()
            .AddScoped<IGetRoleByWorkspaceIdAndUserIdService, GetRoleByWorkspaceIdAndUserIdService>();

        return services;
    }

    /// <summary>
    /// To add services from 3rd parties
    /// </summary>
    private static IServiceCollection AddExternalServices(this IServiceCollection services)
    {
        services.AddHttpClient<GoogleAuthentication>();
        
        services
            .AddScoped<IGoogleAuthentication, GoogleAuthentication>();

        return services;
    }

    private static IServiceCollection AddApplicationOptions(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<GoogleAuthenticationOptions>(configuration.GetSection(nameof(GoogleAuthenticationOptions)));

        return services;
    }
}