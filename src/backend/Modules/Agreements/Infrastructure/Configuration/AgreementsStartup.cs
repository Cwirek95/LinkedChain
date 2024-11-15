using LinkedChain.BuildingBlocks.Application;
using LinkedChain.BuildingBlocks.Infrastructure.Common;
using LinkedChain.BuildingBlocks.Infrastructure.EventBus;
using LinkedChain.Modules.Agreements.Infrastructure.Configuration.Authenctication;
using LinkedChain.Modules.Agreements.Infrastructure.Configuration.DataAccess;
using LinkedChain.Modules.Agreements.Infrastructure.Configuration.EventsBus;
using LinkedChain.Modules.Agreements.Infrastructure.Configuration.Mediator;
using LinkedChain.Modules.Agreements.Infrastructure.Configuration.Outbox;
using LinkedChain.Modules.Agreements.Infrastructure.Configuration.Quartz;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Quartz;
using Serilog;
using Serilog.Extensions.Logging;
using System.Reflection;

namespace LinkedChain.Modules.Agreements.Infrastructure.Configuration;

public class AgreementsStartup
{
    public static void Initialize(
        IServiceCollection services,
        string connectionString,
        IExecutionContextAccessor executionContextAccessor,
        ILogger logger,
        IEventsBus eventsBus,
        long? internalProcessingPoolingInterval = null)
    {
        var moduleLogger = logger.ForContext("Module", "Agreements");

        ConfigureCompositionRoot(
            services,
            connectionString,
            executionContextAccessor,
            moduleLogger,
            eventsBus);

        QuartzStartup.Initialize(moduleLogger, internalProcessingPoolingInterval);

        EventsBusStartup.Initialize(moduleLogger);
    }

    public static void Stop()
    {
        QuartzStartup.StopQuartz();
    }

    private static void ConfigureCompositionRoot(
        IServiceCollection services,
        string connectionString,
        IExecutionContextAccessor executionContextAccessor,
        ILogger logger,
        IEventsBus eventsBus)
    {
        var assemblies = new[] { typeof(IMediator).Assembly, Assembly.GetExecutingAssembly() };
        var assembly = typeof(IJob).Assembly;

        services.AddSingleton(logger.ForContext("Module", "Agreements"));

        var loggerFactory = new SerilogLoggerFactory(logger);
        services.AddDataAccessModule(connectionString, loggerFactory);
        services.AddEventsBusModule(eventsBus);
        services.AddMediationModule(assemblies);
        services.AddAuthenticationModule();

        var domainNotificationsMap = new BiDictionary<string, Type>();
        services.AddOutboxModule(domainNotificationsMap);
        services.AddQuartzModule(assembly);

        services.AddSingleton(executionContextAccessor);
    }
}