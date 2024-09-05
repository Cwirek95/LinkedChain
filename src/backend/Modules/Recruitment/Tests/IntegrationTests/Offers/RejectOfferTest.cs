using LinkedChain.Modules.Recruitment.Application.Offers.CreateB2BContractOffer;
using LinkedChain.Modules.Recruitment.Application.Offers.CreateMandateContractOffer;
using LinkedChain.Modules.Recruitment.Application.Offers.CreatePermanentContractOffer;
using LinkedChain.Modules.Recruitment.Application.Offers.GetOfferDetails;
using LinkedChain.Modules.Recruitment.Application.Offers.RejectOffer;
using LinkedChain.Modules.Recruitment.Domain.Offer;
using LinkedChain.Modules.Recruitment.IntegrationTests.SeedWork;
using NUnit.Framework;

namespace LinkedChain.Modules.Recruitment.IntegrationTests.Offers;

[TestFixture]
public class RejectOfferTest : TestBase
{
    public async Task RejectB2BOffer_Test()
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
            50.00M));

        await RecruitmentModule.ExecuteCommandAsync(new RejectOfferCommand(offerId));

        var offerDetails = await RecruitmentModule.ExecuteQueryAsync(new GetOfferDetailsQuery(offerId));

        // Assert
        Assert.That(offerDetails, Is.Not.Null);
        Assert.Equals(offerDetails.StatusName, OfferStatus.Rejected.ToString());
    }

    public async Task RejectPermanentContractOffer_Test()
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

        await RecruitmentModule.ExecuteCommandAsync(new RejectOfferCommand(offerId));

        var offerDetails = await RecruitmentModule.ExecuteQueryAsync(new GetOfferDetailsQuery(offerId));

        // Assert
        Assert.That(offerDetails, Is.Not.Null);
        Assert.Equals(offerDetails.StatusName, OfferStatus.Rejected.ToString());
    }

    public async Task RejectMandateContractOffer_Test()
    {
        // Act
        var offerId = await RecruitmentModule.ExecuteCommandAsync(new CreateMandateContractOfferCommand(
            Guid.NewGuid(),
            Guid.NewGuid(),
            "Test description",
            DateTime.UtcNow,
            DateTime.UtcNow.AddDays(30),
            PayPeriod.Daily.ToString(),
            "EUR",
            200.00M));

        await RecruitmentModule.ExecuteCommandAsync(new RejectOfferCommand(offerId));

        var offerDetails = await RecruitmentModule.ExecuteQueryAsync(new GetOfferDetailsQuery(offerId));

        // Assert
        Assert.That(offerDetails, Is.Not.Null);
        Assert.Equals(offerDetails.StatusName, OfferStatus.Rejected.ToString());
    }
}