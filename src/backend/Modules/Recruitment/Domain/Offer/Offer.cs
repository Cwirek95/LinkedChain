using LinkedChain.BuildingBlocks.Domain;
using LinkedChain.Modules.Recruitment.Domain.Users;

namespace LinkedChain.Modules.Recruitment.Domain.Offer;

public class Offer : Entity, IAggregateRoot
{
    public OfferId Id { get; private set; }

    private UserId _employee;
    
    private UserId _employer;

    private OfferStatus _status;

    private ContractType _contractType;
    
    private ContractDuration _contractDuration;

    private Salary _salary;
    
    private DateTime _createDate;
    
    private DateTime _expirationDate;
}