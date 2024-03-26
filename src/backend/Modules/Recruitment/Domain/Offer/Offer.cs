using LinkedChain.BuildingBlocks.Domain;

namespace LinkedChain.Modules.Recruitment.Domain.Offer;

public class Offer : Entity, IAggregateRoot
{
    public OfferId Id { get; private set; }
}