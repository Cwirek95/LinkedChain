using LinkedChain.BuildingBlocks.Domain.Events;

namespace LinkedChain.BuildingBlocks.Application.DomainEvents;

public class DomainNotificationBase<T> : IDomainEventNotification<T> where T : IDomainEvent
{
    public T DomainEvent { get; }

    public Guid Id { get; }

    public DomainNotificationBase(T domainEvent, Guid id)
    {
        Id = id;
        DomainEvent = domainEvent;
    }
}