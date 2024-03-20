namespace LinkedChain.BuildingBlocks.Infrastructure.DomainEvents;

public interface IDomainEventsDispatcher
{
    Task DispatchEventsAsync();
}