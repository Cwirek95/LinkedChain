using LinkedChain.Modules.Recruitment.Domain.Offer;
using LinkedChain.Modules.Recruitment.Domain.SharedKernel;
using LinkedChain.Modules.Recruitment.Domain.UnitTests.SeedWork;
using LinkedChain.Modules.Recruitment.Domain.Users;

namespace LinkedChain.Modules.Recruitment.Domain.UnitTests.Offers;

public class OfferTestsBase : TestBase
{
    protected Offer.Offer CreateExpiredPermanentIndefinitelyContractOfferTestData()
    {
        var offer = Offer.Offer.CreateNew(
            new UserId(Guid.NewGuid()),
            new UserId(Guid.NewGuid()),
            "Description",
            ContractType.Permanent,
            ContractDuration.CreateNewIndefinitely(SystemClock.Now),
            Salary.Of(5000, "PLN", PayPeriod.Monthly));
        
        offer.Expire();

        return offer;
    }

    protected Offer.Offer CreateAcceptedPermanentIndefinitelyContractOfferTestData()
    {
        var offer = Offer.Offer.CreateNew(
            new UserId(Guid.NewGuid()),
            new UserId(Guid.NewGuid()),
            "Description",
            ContractType.Permanent,
            ContractDuration.CreateNewIndefinitely(SystemClock.Now),
            Salary.Of(5000, "PLN", PayPeriod.Monthly));
        
        offer.Accept();

        return offer;
    }

    protected Offer.Offer CreateRejectedPermanentIndefinitelyContractOfferTestData()
    {
        var offer = Offer.Offer.CreateNew(
            new UserId(Guid.NewGuid()),
            new UserId(Guid.NewGuid()),
            "Description",
            ContractType.Permanent,
            ContractDuration.CreateNewIndefinitely(SystemClock.Now),
            Salary.Of(5000, "PLN", PayPeriod.Monthly));
        
        offer.Reject();

        return offer;
    }
}