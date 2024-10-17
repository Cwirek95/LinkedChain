using LinkedChain.BuildingBlocks.Application.DomainEvents;
using LinkedChain.BuildingBlocks.Application.Outbox;
using LinkedChain.BuildingBlocks.Infrastructure.Common;
using LinkedChain.BuildingBlocks.Infrastructure.DomainEvents;
using LinkedChain.Modules.Agreements.Infrastructure.Outbox;
using Microsoft.Extensions.DependencyInjection;

namespace LinkedChain.Modules.Agreements.Infrastructure.Configuration.Outbox;

public static class OutboxModule
{
    public static IServiceCollection AddOutboxModule(this IServiceCollection services, BiDictionary<string, Type> domainNotificationsMap)
    {
        services.AddScoped<IOutbox, OutboxAccessor>();

        CheckMappings(domainNotificationsMap);

        services.AddSingleton<IDomainNotificationsMapper>(provider => new DomainNotificationsMapper(domainNotificationsMap));

        return services;
    }

    private static void CheckMappings(BiDictionary<string, Type> domainNotificationsMap)
    {
        var domainEventNotifications = Assemblies.Application
            .GetTypes()
            .Where(x => x.GetInterfaces().Contains(typeof(IDomainEventNotification)))
            .ToList();

        var notMappedNotifications = new List<Type>();
        foreach (var domainEventNotification in domainEventNotifications)
        {
            domainNotificationsMap.TryGetBySecond(domainEventNotification, out var name);

            if (name == null)
            {
                notMappedNotifications.Add(domainEventNotification);
            }
        }

        if (notMappedNotifications.Any())
        {
            throw new ApplicationException($"Domain Event Notifications {string.Join(",", notMappedNotifications.Select(x => x.FullName))} not mapped");
        }
    }
}