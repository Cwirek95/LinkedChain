using MediatR;

namespace LinkedChain.BuildingBlocks.Domain.Events;

public interface IDomainEvent : INotification
{
    Guid Id { get; }

    DateTime OccurredOn { get; }
}