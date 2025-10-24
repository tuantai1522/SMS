using SMS.Web.Extensions;
using SMS.Web.Infrastructure;

namespace SMS.Web;

public static class DependencyInjection
{
    public static void AddWeb(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        
        services.AddCorsPolicy(configuration);
        
        services.AddExceptionHandler<GlobalExceptionHandler>();
        services.AddProblemDetails();
        
    }
}