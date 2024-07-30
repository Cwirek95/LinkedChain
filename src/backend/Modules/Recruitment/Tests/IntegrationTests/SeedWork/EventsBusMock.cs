using LinkedChain.BuildingBlocks.Infrastructure.EventBus;

namespace LinkedChain.Modules.Recruitment.IntegrationTests.SeedWork;

public class EventsBusMock : IEventsBus
{
    private readonly IList<IntegrationEvent> _publishedEvents;

    public EventsBusMock()
    {
        _publishedEvents = new List<IntegrationEvent>();
    }

    public void Dispose()
    {
    }

    public Task Publish<T>(T @event)
        where T : IntegrationEvent
    {
        _publishedEvents.Add(@event);
        return Task.CompletedTask;
    }

    public T GetLastPublishedEvent<T>()
        where T : IntegrationEvent
    {
        return _publishedEvents.OfType<T>().Last();
    }

    public void Subscribe<T>(IIntegrationEventHandler<T> handler)
        where T : IntegrationEvent
    {
    }

    public void StartConsuming()
    {
    }
}