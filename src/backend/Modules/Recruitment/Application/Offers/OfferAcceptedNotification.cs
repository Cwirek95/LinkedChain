using LinkedChain.BuildingBlocks.Application.DomainEvents;
using LinkedChain.Modules.Recruitment.Domain.Offer.Events;
using Newtonsoft.Json;

namespace LinkedChain.Modules.Recruitment.Application.Offers;

public class OfferAcceptedNotification : DomainNotificationBase<OfferAcceptedDomainEvent>
{
    [JsonConstructor]
    public OfferAcceptedNotification(OfferAcceptedDomainEvent domainEvent, Guid id) 
        : base(domainEvent, id)
    {
    }
}