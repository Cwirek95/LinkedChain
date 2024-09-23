using LinkedChain.BuildingBlocks.Domain;
using LinkedChain.Modules.Agreements.Domain.Events;
using LinkedChain.Modules.Agreements.Domain.SharedKernel;
using LinkedChain.Modules.Agreements.Domain.Users;

namespace LinkedChain.Modules.Agreements.Domain.Agreement;

public class PernamentContractAgreement : Entity, IAggregateRoot
{
    public AgreementId Id { get; private set; }

    private OfferId _offer;

    private UserId _employee;

    private UserId _employer;

    private string _description;

    private AgreementDuration _agreementDuration;

    private Salary _salary;

    private bool _isSigned;

    private DateTime _createDate;

    private DateTime? _signatureDate;

    private PernamentContractAgreement(
        OfferId offer,
        UserId employee,
        UserId employer,
        string description,
        AgreementDuration agreementDuration,
        Salary salary)
    {
        Id = new AgreementId(Guid.NewGuid());
        _offer = offer;
        _employee = employee;
        _employer = employer;
        _description = description;
        _agreementDuration = agreementDuration;
        _salary = salary;
        _createDate = SystemClock.Now;

        AddDomainEvent(new AgreementCreatedDomainEvent(Id));
    }

    private PernamentContractAgreement()
    {
        // EF required
    }

    public static PernamentContractAgreement CreateNew(
        OfferId offerId,
        UserId employee,
        UserId employer,
        string descritption,
        AgreementDuration agreementDuration,
        Salary salary)
    {
        return new PernamentContractAgreement(
            offerId,
            employee,
            employer,
            descritption,
            agreementDuration,
            salary);
    }

    public void Sign(DateTime signatureDate)
    {
        _isSigned = true;
        _signatureDate = signatureDate;

        AddDomainEvent(new AgreementSignedDomainEvent(Id));
    }
}