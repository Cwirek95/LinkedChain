using LinkedChain.Modules.Agreements.Domain.Agreement;
using LinkedChain.Modules.Agreements.Domain.SharedKernel;
using LinkedChain.Modules.Agreements.Domain.UnitTests.SeedWork;
using LinkedChain.Modules.Agreements.Domain.Users;

namespace LinkedChain.Modules.Agreements.Domain.UnitTests.Agreements;

public class AgreementTestBase : TestBase
{
    protected PernamentContractAgreement CreatePermanentContractAgreementTestData()
    {
        return PernamentContractAgreement.CreateNew(
            new OfferId(Guid.NewGuid()),
            new UserId(Guid.NewGuid()),
            new UserId(Guid.NewGuid()),
            "Description",
            AgreementDuration.Create(SystemClock.Now, SystemClock.Now.AddMonths(12)),
            Salary.Of(5000, "PLN", PayPeriod.Monthly));
    }

    protected MandateContractAgreement CreateMandateContractAgreementTestData()
    {
        return MandateContractAgreement.CreateNew(
            new OfferId(Guid.NewGuid()),
            new UserId(Guid.NewGuid()),
            new UserId(Guid.NewGuid()),
            "Description",
            AgreementDuration.Create(SystemClock.Now, SystemClock.Now.AddMonths(1)),
            Salary.Of(50, "PLN", PayPeriod.Hourly));
    }

    protected B2BAgreement CreateB2BAgreementTestData()
    {
        return B2BAgreement.CreateNew(
            new OfferId(Guid.NewGuid()),
            new UserId(Guid.NewGuid()),
            new UserId(Guid.NewGuid()),
            "Description",
            AgreementDuration.Create(SystemClock.Now, SystemClock.Now.AddMonths(6)),
            Salary.Of(350, "PLN", PayPeriod.Daily));
    }
}