using LinkedChain.BuildingBlocks.Infrastructure.EventBus;
using LinkedChain.Modules.Recruitment.IntegrationEvents;
using MediatR;

namespace LinkedChain.Modules.Recruitment.Application.Offers;

public class OfferAcceptedNotificationHandler : INotificationHandler<OfferAcceptedNotification>
{
    private readonly IEventsBus _eventsBus;

    public OfferAcceptedNotificationHandler(IEventsBus eventsBus)
    {
        _eventsBus = eventsBus;
    }

    public async Task Handle(OfferAcceptedNotification notification, CancellationToken cancellationToken)
    {
        await _eventsBus.Publish(new OfferAcceptedIntegrationEvent(
            Guid.NewGuid(),
            notification.DomainEvent.OccurredOn,
            notification.DomainEvent.EmployeeId,
            notification.DomainEvent.EmployerId,
            notification.DomainEvent.ContractType,
            notification.DomainEvent.SalaryPeriod,
            notification.DomainEvent.SalaryCurrency,
            notification.DomainEvent.SalaryAmount,
            notification.DomainEvent.StartDate,
            notification.DomainEvent.EndDate));
    }
}