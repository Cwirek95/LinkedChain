using LinkedChain.BuildingBlocks.Domain.Events;

namespace LinkedChain.Modules.Recruitment.Domain.Offer.Events;

public class OfferAcceptedDomainEvent : DomainEventBase
{
    public OfferId OfferId { get; }

    public OfferAcceptedDomainEvent(OfferId offerId)
    {
        OfferId = offerId;
    }
}