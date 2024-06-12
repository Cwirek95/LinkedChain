using LinkedChain.BuildingBlocks.Domain.Events;
using LinkedChain.Modules.Recruitment.Domain.Users;

namespace LinkedChain.Modules.Recruitment.Domain.Offer.Events;

public class OfferCreatedDomainEvent : DomainEventBase
{
    public OfferId OfferId { get; }
    
    public UserId Employee { get; }

    public UserId Employer { get; }

    public ContractType ContractType { get; }

    public ContractDuration ContractDuration { get; }

    public Salary Salary { get; }

    public OfferCreatedDomainEvent(
        OfferId offerId,
        UserId employee,
        UserId employer,
        ContractType contractType,
        ContractDuration contractDuration,
        Salary salary)
    {
        OfferId = offerId;
        Employee = employee;
        Employer = employer;
        ContractType = contractType;
        ContractDuration = contractDuration;
        Salary = salary;
    }
}