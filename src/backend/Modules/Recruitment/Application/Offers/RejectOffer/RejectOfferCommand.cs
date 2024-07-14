using LinkedChain.Modules.Recruitment.Application.Contracts;

namespace LinkedChain.Modules.Recruitment.Application.Offers.RejectOffer;

public sealed class RejectOfferCommand : CommandBase
{
    public RejectOfferCommand(Guid offerId)
    {
        OfferId = offerId;
    }

    public Guid OfferId { get; }
}