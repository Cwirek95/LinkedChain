using LinkedChain.BuildingBlocks.Domain;
using LinkedChain.Modules.Recruitment.Domain.SharedKernel;
using LinkedChain.Modules.Recruitment.Domain.Users;

namespace LinkedChain.Modules.Recruitment.Domain.Offer;

public class Offer : Entity, IAggregateRoot
{
    public OfferId Id { get; private set; }

    private UserId _employee;
    
    private UserId _employer;

    private string _description;

    private OfferStatus _status;

    private ContractType _contractType;
    
    private ContractDuration _contractDuration;

    private Salary _salary;
    
    private DateTime _createDate;
    
    private DateTime _expirationDate;

    private Offer(
        UserId employee,
        UserId employer,
        string description,
        ContractType contractType,
        ContractDuration contractDuration,
        Salary salary)
    {
        Id = new OfferId(Guid.NewGuid());
        _employee = employee;
        _employer = employer;
        _description = description;
        _status = OfferStatus.Sent;
        _contractType = contractType;
        _contractDuration = contractDuration;
        _salary = salary;
        _createDate = SystemClock.Now;
        _expirationDate = SystemClock.Now.AddDays(7);
    }
}