using LinkedChain.BuildingBlocks.Domain.Events;

namespace LinkedChain.Modules.Recruitment.Domain.Offer.Events;

public class OfferExpiredDomainEvent : DomainEventBase
{
    public OfferId OfferId { get; }
    
    public OfferExpiredDomainEvent(OfferId offerId)
    {
        OfferId = offerId;
    }
}