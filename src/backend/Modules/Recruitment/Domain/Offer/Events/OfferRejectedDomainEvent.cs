using LinkedChain.BuildingBlocks.Domain.Events;

namespace LinkedChain.Modules.Recruitment.Domain.Offer.Events;

public class OfferRejectedDomainEvent : DomainEventBase
{
    public OfferId OfferId { get; }

    public OfferRejectedDomainEvent(OfferId offerId)
    {
        OfferId = offerId;
    }
}