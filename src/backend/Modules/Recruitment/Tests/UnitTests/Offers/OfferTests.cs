using FluentAssertions;
using LinkedChain.Modules.Recruitment.Domain.Offer.Events;
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
    
    [Test]
    public void ExpireOffer_WhenOfferIsInSentStatus_IsSuccessful()
    {
        var offer = CreateSentPermanentIndefinitelyContractOfferTestData();

        var offerCreated = AssertPublishedDomainEvent<OfferCreatedDomainEvent>(offer);
        offerCreated.OfferId.Should().Be(offer.Id);
    }
    
    [Test]
    public void AcceptOffer_WhenOfferIsAccepted_IsNotPossible()
    {
        var offer = CreateAcceptedPermanentIndefinitelyContractOfferTestData();

        AssertBrokenRule<OnlySentStatusOfferCanBeAcceptRule>(() =>
        {
            offer.Accept();
        });
    }
    
    [Test]
    public void AcceptOffer_WhenOfferIsRejected_IsNotPossible()
    {
        var offer = CreateRejectedPermanentIndefinitelyContractOfferTestData();

        AssertBrokenRule<OnlySentStatusOfferCanBeAcceptRule>(() =>
        {
            offer.Accept();
        });
    }
    
    [Test]
    public void AcceptOffer_WhenOfferIsExpired_IsNotPossible()
    {
        var offer = CreateExpiredPermanentIndefinitelyContractOfferTestData();

        AssertBrokenRule<OnlySentStatusOfferCanBeAcceptRule>(() =>
        {
            offer.Accept();
        });
    }
    
    [Test]
    public void AcceptOffer_WhenOfferIsSentStatus_IsSuccessful()
    {
        var offer = CreateSentPermanentIndefinitelyContractOfferTestData();
        offer.Accept();

        var offerAccepted = AssertPublishedDomainEvent<OfferAcceptedDomainEvent>(offer);
        offerAccepted.OfferId.Should().Be(offer.Id);
    }
}