using MediatR;

namespace LinkedChain.BuildingBlocks.Infrastructure.EventBus;

public class IntegrationEvent : INotification
{
    public Guid Id { get; }

    public DateTime OccurredOn { get; }

    protected IntegrationEvent(Guid id, DateTime occurredOn)
    {
        Id = id;
        OccurredOn = occurredOn;
    }
}