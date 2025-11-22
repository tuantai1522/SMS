using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using SMS.Core.Common;
using SMS.Core.Features.Channels;
using SMS.Core.Features.Countries;
using SMS.Core.Features.Posts;
using SMS.Core.Features.Projects;
using SMS.Core.Features.RefreshTokens;
using SMS.Core.Features.Tasks;
using SMS.Core.Features.Teams;
using SMS.Core.Features.Users;
using SMS.Core.Features.Workspaces;
using SMS.Infrastructure.Authentication;
using SMS.Infrastructure.Database;
using SMS.Infrastructure.Queries.Tasks;
using SMS.Infrastructure.Repositories;
using SMS.Infrastructure.WebStorages;
using SMS.UseCases.Abstractions.Authentication;
using SMS.UseCases.Abstractions.Data;
using SMS.UseCases.Abstractions.WebStorages;
using SMS.UseCases.Features.Tasks.GetTasksByWorkspaceId;

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
            .AddScoped<ICountryRepository, CountryRepository>()
            
            .AddScoped<ITaskStatusRepository, TaskStatusRepository>()
            .AddScoped<ITaskPriorityRepository, TaskPriorityRepository>()
            
            .AddScoped<IRoleRepository, RoleRepository>()
            .AddScoped<IProjectRepository, ProjectRepository>()
            .AddScoped<IWorkspaceRepository, WorkspaceRepository>()
            .AddScoped<IWorkspaceMemberRepository, WorkspaceMemberRepository>()
            .AddScoped<IUserRepository, UserRepository>();

        return services;
    }
    
    private static IServiceCollection AddAuthenticationInternal(
        this IServiceCollection services,
        IConfiguration configuration)
    {
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
            .AddScoped<IGetTasksByWorkspaceIdService, GetTasksByWorkspaceIdService>();

        return services;
    }
}