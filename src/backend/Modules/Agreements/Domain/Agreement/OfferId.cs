using LinkedChain.BuildingBlocks.Domain;

namespace LinkedChain.Modules.Agreements.Domain.Agreement;

public class OfferId : TypedIdValueBase
{
    public OfferId(Guid value)
        : base(value)
    {
    }
}