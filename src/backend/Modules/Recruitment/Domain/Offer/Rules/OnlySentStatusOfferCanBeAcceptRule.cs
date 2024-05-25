using LinkedChain.BuildingBlocks.Domain;

namespace LinkedChain.Modules.Recruitment.Domain.Offer.Rules;

public class OnlySentStatusOfferCanBeAcceptRule : IBusinessRule
{
    private readonly OfferStatus _offerStatus;

    public OnlySentStatusOfferCanBeAcceptRule(OfferStatus offerStatus)
    {
        _offerStatus = offerStatus;
    }

    public bool IsBroken() => _offerStatus.Code != OfferStatus.Sent.Code;

    public string Message => "An offer that has already expired or been accepted/rejected cannot be accept";
}