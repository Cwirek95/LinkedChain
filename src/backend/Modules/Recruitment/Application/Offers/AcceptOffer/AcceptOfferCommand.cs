using LinkedChain.Modules.Recruitment.Application.Contracts;

namespace LinkedChain.Modules.Recruitment.Application.Offers.AcceptOffer;

public sealed class AcceptOfferCommand : CommandBase
{
    public AcceptOfferCommand(Guid offerId)
    {
        OfferId = offerId;
    }

    public Guid OfferId { get; }
}