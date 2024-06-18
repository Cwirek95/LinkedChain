using Microsoft.Extensions.DependencyInjection;
using Serilog;

namespace LinkedChain.Modules.Recruitment.Infrastructure.Configuration.Logging;

public static class LoggingModule
{
    public static IServiceCollection AddLoggingModule(this IServiceCollection services, ILogger logger)
    {
        services.AddSingleton(logger);
        
        return services;
    }
}