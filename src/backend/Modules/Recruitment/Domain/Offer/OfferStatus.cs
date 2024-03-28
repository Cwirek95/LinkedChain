using LinkedChain.BuildingBlocks.Domain;

namespace LinkedChain.Modules.Recruitment.Domain.Offer;

public class OfferStatus : ValueObject
{
    public static OfferStatus Sent => new OfferStatus(nameof(Sent));
    public static OfferStatus Accepted => new OfferStatus(nameof(Accepted));
    public static OfferStatus Rejected => new OfferStatus(nameof(Rejected));
    public static OfferStatus Expired => new OfferStatus(nameof(Expired));
    public string Code { get; }
    
    private OfferStatus(string code)
    {
        Code = code;
    }
    
    public static OfferStatus Of(string code)
    {
        return new OfferStatus(code);
    }
}