using LinkedChain.BuildingBlocks.Application.DomainEvents;
using LinkedChain.BuildingBlocks.Application.Outbox;
using LinkedChain.BuildingBlocks.Domain.Events;
using LinkedChain.BuildingBlocks.Infrastructure.Serializations;
using MediatR;
using Newtonsoft.Json;

namespace LinkedChain.BuildingBlocks.Infrastructure.DomainEvents;

public class DomainEventsDispatcher : IDomainEventsDispatcher
{
    private readonly IMediator _mediator;
    private readonly IOutbox _outbox;
    private readonly IDomainEventsAccessor _domainEventsProvider;
    private readonly IDomainNotificationsMapper _domainNotificationsMapper;

    public DomainEventsDispatcher(
        IMediator mediator,
        IOutbox outbox,
        IDomainEventsAccessor domainEventsProvider,
        IDomainNotificationsMapper domainNotificationsMapper)
    {
        _mediator = mediator;
        _outbox = outbox;
        _domainEventsProvider = domainEventsProvider;
        _domainNotificationsMapper = domainNotificationsMapper;
    }

    public async Task DispatchEventsAsync()
    {
        var domainEvents = _domainEventsProvider.GetAllDomainEvents();

        var domainEventNotifications = new List<IDomainEventNotification<IDomainEvent>>();
        foreach (var domainEvent in domainEvents)
        {
            Type domainEventNotificationType = typeof(IDomainEventNotification<>);
            var domainNotificationWithGenericType = domainEventNotificationType.MakeGenericType(domainEvent.GetType());
            var domainNotification = (IDomainEventNotification<IDomainEvent>)Activator.CreateInstance(domainNotificationWithGenericType, domainEvent, domainEvent.Id);

            domainEventNotifications.Add(domainNotification);
        }

        _domainEventsProvider.ClearAllDomainEvents();

        foreach (var domainEvent in domainEvents)
        {
            await _mediator.Publish(domainEvent);
        }

        foreach (var domainEventNotification in domainEventNotifications)
        {
            var type = _domainNotificationsMapper.GetName(domainEventNotification.GetType());
            var data = JsonConvert.SerializeObject(domainEventNotification, new JsonSerializerSettings
            {
                ContractResolver = new AllPropertiesContractResolver()
            });

            var outboxMessage = new OutboxMessage(
                domainEventNotification.Id,
                domainEventNotification.DomainEvent.OccurredOn,
                type,
                data);

            _outbox.Add(outboxMessage);
        }
    }
}