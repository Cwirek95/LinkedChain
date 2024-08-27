using LinkedChain.Modules.Recruitment.Application.Offers.CreateB2BContractOffer;
using LinkedChain.Modules.Recruitment.Application.Offers.CreateMandateContractOffer;
using LinkedChain.Modules.Recruitment.Application.Offers.CreatePermanentContractOffer;
using LinkedChain.Modules.Recruitment.Application.Offers.GetOfferDetails;
using LinkedChain.Modules.Recruitment.Domain.Offer;
using LinkedChain.Modules.Recruitment.IntegrationTests.SeedWork;
using NUnit.Framework;

namespace LinkedChain.Modules.Recruitment.IntegrationTests.Offers;

[TestFixture]
public class CreateOfferTest : TestBase
{
    [Test]
    public async Task CreatePermanentContractOffer_Test()
    {
        // Act
        var offerId = await RecruitmentModule.ExecuteCommandAsync(new CreatePermanentContractOfferCommand(
            Guid.NewGuid(),
            Guid.NewGuid(),
            "Test description",
            DateTime.UtcNow,
            DateTime.UtcNow.AddDays(30),
            PayPeriod.Hourly.ToString(),
            "PLN",
            30.00M));

        var offerDetails = await RecruitmentModule.ExecuteQueryAsync(new GetOfferDetailsQuery(offerId));

        // Assert
        Assert.That(offerDetails, Is.Not.Null);
    }

    [Test]
    public async Task CreateB2BContractOffer_Test()
    {
        // Act
        var offerId = await RecruitmentModule.ExecuteCommandAsync(new CreateB2BContractOfferCommand(
            Guid.NewGuid(),
            Guid.NewGuid(),
            "Test description",
            DateTime.UtcNow,
            DateTime.UtcNow.AddDays(30),
            PayPeriod.Hourly.ToString(),
            "PLN",
            30.00M));

        var offerDetails = await RecruitmentModule.ExecuteQueryAsync(new GetOfferDetailsQuery(offerId));

        // Assert
        Assert.That(offerDetails, Is.Not.Null);
    }

    [Test]
    public async Task CreateMandateContractOffer_Test()
    {
        // Act
        var offerId = await RecruitmentModule.ExecuteCommandAsync(new CreateMandateContractOfferCommand(
            Guid.NewGuid(),
            Guid.NewGuid(),
            "Test description",
            DateTime.UtcNow,
            DateTime.UtcNow.AddDays(30),
            PayPeriod.Hourly.ToString(),
            "PLN",
            30.00M));

        var offerDetails = await RecruitmentModule.ExecuteQueryAsync(new GetOfferDetailsQuery(offerId));

        // Assert
        Assert.That(offerDetails, Is.Not.Null);
    }
}