using LinkedChain.BuildingBlocks.Domain;

namespace LinkedChain.Modules.Recruitment.Domain.Offer;

public class OfferId : TypedIdValueBase
{
    public OfferId(Guid value)
        : base(value)
    {
    }
}