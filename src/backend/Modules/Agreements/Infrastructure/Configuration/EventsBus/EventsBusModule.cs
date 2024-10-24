using LinkedChain.BuildingBlocks.Infrastructure.EventBus;
using Microsoft.Extensions.DependencyInjection;

namespace LinkedChain.Modules.Agreements.Infrastructure.Configuration.EventsBus;

public static class EventsBusModule
{
    public static IServiceCollection AddEventsBusModule(this IServiceCollection services, IEventsBus eventsBus = null)
    {
        if (eventsBus is null)
        {
            services.AddSingleton(eventsBus);
        }
        else
        {
            services.AddSingleton<IEventsBus, InMemoryEventBusClient>();
        }
        return services;
    }
}