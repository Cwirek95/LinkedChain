using LinkedChain.BuildingBlocks.Domain;

namespace LinkedChain.Modules.Agreements.Domain.Agreement;

public class AgreementId : TypedIdValueBase
{
    public AgreementId(Guid value)
        : base(value)
    {
    }
}