using LinkedChain.Modules.Recruitment.Application.Contracts;

namespace LinkedChain.Modules.Recruitment.Application.Offers.GetOfferDetails;

public class GetOfferDetailsQuery : QueryBase<OfferDetailsDto>
{
    public GetOfferDetailsQuery(Guid offerId)
    {
        OfferId = offerId;

    }

    public Guid OfferId { get; }
}