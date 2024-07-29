using LinkedChain.BuildingBlocks.Domain;
using LinkedChain.Modules.Recruitment.Domain.Offer.Events;
using LinkedChain.Modules.Recruitment.Domain.Offer.Rules;
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
        CheckRule(new DurationOfContractMustBeDefinedStartDateRule(contractDuration));

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
        
        AddDomainEvent(new OfferCreatedDomainEvent(
            Id,
            employee,
            employer,
            contractType,
            contractDuration,
            salary));
    }
    
    private Offer()
    {
        // EF required
    }

    public static Offer CreateNew(
        UserId employee,
        UserId employer,
        string description,
        ContractType contractType,
        ContractDuration contractDuration,
        Salary salary)
    {
        return new Offer(
            employee,
            employer,
            description,
            contractType,
            contractDuration,
            salary);
    }

    public void Expire()
    {
        CheckRule(new OnlySentStatusOfferCanBeExpireRule(_status));
        
        _status = OfferStatus.Expired;
        AddDomainEvent(new OfferExpiredDomainEvent(Id));
    }

    public void Accept()
    {
        CheckRule(new OnlySentStatusOfferCanBeAcceptRule(_status));
        
        _status = OfferStatus.Accepted;
        AddDomainEvent(new OfferAcceptedDomainEvent(Id, _employee.Value, _employer.Value, _contractType.Type, _salary.Period.Period,
            _salary.Currency, _salary.Amount, _contractDuration.StartDate, _contractDuration.EndDate));
    }

    public void Reject()
    {
        CheckRule(new OnlySentStatusOfferCanBeRejectRule(_status));
        
        _status = OfferStatus.Rejected;
        AddDomainEvent(new OfferRejectedDomainEvent(Id));
    }
}