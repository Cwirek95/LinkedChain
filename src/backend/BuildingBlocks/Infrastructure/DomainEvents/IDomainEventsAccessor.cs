using LinkedChain.BuildingBlocks.Domain.Events;

namespace LinkedChain.BuildingBlocks.Infrastructure.DomainEvents;

public interface IDomainEventsAccessor
{
    IReadOnlyCollection<IDomainEvent> GetAllDomainEvents();

    void ClearAllDomainEvents();
}