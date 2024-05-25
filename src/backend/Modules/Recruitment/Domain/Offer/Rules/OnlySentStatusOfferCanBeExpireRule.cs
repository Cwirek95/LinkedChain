using LinkedChain.BuildingBlocks.Domain;

namespace LinkedChain.Modules.Recruitment.Domain.Offer.Rules;

public class OnlySentStatusOfferCanBeExpireRule : IBusinessRule
{
    private readonly OfferStatus _offerStatus;

    public OnlySentStatusOfferCanBeExpireRule(OfferStatus offerStatus)
    {
        _offerStatus = offerStatus;
    }

    public bool IsBroken() => _offerStatus.Code != OfferStatus.Sent.Code;

    public string Message => "An offer that has already expired or been accepted/rejected cannot expire";
}