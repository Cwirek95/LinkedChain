using LinkedChain.BuildingBlocks.Infrastructure.EventBus;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

namespace LinkedChain.Modules.Agreements.Infrastructure.Configuration.EventsBus;

public static class EventsBusStartup
{
    public static void Initialize(
        ILogger logger)
    {
        SubscribeToIntegrationEvents(logger);
    }

    private static void SubscribeToIntegrationEvents(ILogger logger)
    {
        var eventBus = AgreementsCompositionRoot.BeginLifetimeScope().ServiceProvider.GetRequiredService<IEventsBus>();
    }

    private static void SubscribeToIntegrationEvent<T>(IEventsBus eventBus, ILogger logger)
        where T : IntegrationEvent
    {
        logger.Information("Subscribe to {@IntegrationEvent}", typeof(T).FullName);
        eventBus.Subscribe(
            new IntegrationEventGenericHandler<T>());
    }
}