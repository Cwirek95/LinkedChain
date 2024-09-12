using LinkedChain.Modules.Agreements.Domain.SharedKernel;
using LinkedChain.Modules.Agreements.Domain.Users;

namespace LinkedChain.Modules.Agreements.Domain.Agreement;

public class PernamentContractAgreement
{
    public AgreementId Id { get; private set; }

    private OfferId _offer;

    private UserId _employee;

    private UserId _employer;

    private string _description;

    private AgreementDuration _agreementDuration;

    private Salary _salary;

    private DateTime _createDate;

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
    }

    private PernamentContractAgreement()
    {
        // EF required
    }
}