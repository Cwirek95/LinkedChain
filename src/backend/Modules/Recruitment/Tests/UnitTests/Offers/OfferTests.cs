using LinkedChain.Modules.Recruitment.Domain.Offer.Rules;
using NUnit.Framework;

namespace LinkedChain.Modules.Recruitment.Domain.UnitTests.Offers;

[TestFixture]
public class OfferTests : OfferTestsBase
{
    [Test]
    public void ExpireOffer_WhenOfferIsExpired_IsNotPossible()
    {
        var offer = CreateExpiredPermanentIndefinitelyContractOfferTestData();

        AssertBrokenRule<OnlySentStatusOfferCanBeExpireRule>(() =>
        {
            offer.Expire();
        });
    }
    
    [Test]
    public void ExpireOffer_WhenOfferIsAccepted_IsNotPossible()
    {
        var offer = CreateAcceptedPermanentIndefinitelyContractOfferTestData();

        AssertBrokenRule<OnlySentStatusOfferCanBeExpireRule>(() =>
        {
            offer.Expire();
        });
    }
    
    [Test]
    public void ExpireOffer_WhenOfferIsRejected_IsNotPossible()
    {
        var offer = CreateRejectedPermanentIndefinitelyContractOfferTestData();

        AssertBrokenRule<OnlySentStatusOfferCanBeExpireRule>(() =>
        {
            offer.Expire();
        });
    }
}