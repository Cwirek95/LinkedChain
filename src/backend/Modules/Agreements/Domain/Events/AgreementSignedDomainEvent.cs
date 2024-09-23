using LinkedChain.BuildingBlocks.Domain.Events;
using LinkedChain.Modules.Agreements.Domain.Agreement;

namespace LinkedChain.Modules.Agreements.Domain.Events;

public class AgreementSignedDomainEvent : DomainEventBase
{
    public AgreementId AgreementId { get; }

    public AgreementSignedDomainEvent(AgreementId agreementId)
    {
        AgreementId = agreementId;
    }

}