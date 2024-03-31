using LinkedChain.BuildingBlocks.Domain;

namespace LinkedChain.Modules.Recruitment.Domain.Offer;

public class Offer : Entity, IAggregateRoot
{
    public OfferId Id { get; private set; }

    private OfferStatus _status;

    private ContractType _contractType;

    private ContractDuration _contractDuration;
}