using Microsoft.Extensions.DependencyInjection;
using Serilog;

namespace LinkedChain.Modules.Agreements.Infrastructure.Configuration.Logging;

public static class LoggingModule
{
    public static IServiceCollection AddLoggingModule(this IServiceCollection services, ILogger logger)
    {
        services.AddSingleton(logger);

        return services;
    }
}