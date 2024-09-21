using LinkedChain.BuildingBlocks.Domain.Events;
using LinkedChain.Modules.Agreements.Domain.Agreement;

namespace LinkedChain.Modules.Agreements.Domain.Events;

public class AgreementCreatedDomainEvent : DomainEventBase
{
    public AgreementId AgreementId { get; }

    public AgreementCreatedDomainEvent(
        AgreementId agreementId)
    {
        AgreementId = agreementId;
    }
}