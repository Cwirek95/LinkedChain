using LinkedChain.Modules.Recruitment.Application.Offers.AcceptOffer;
using LinkedChain.Modules.Recruitment.Application.Offers.CreatePermanentContractOffer;
using LinkedChain.Modules.Recruitment.Application.Offers.GetOfferDetails;
using LinkedChain.Modules.Recruitment.Domain.Offer;
using LinkedChain.Modules.Recruitment.IntegrationTests.SeedWork;
using NUnit.Framework;

namespace LinkedChain.Modules.Recruitment.IntegrationTests.Offers;

[TestFixture]
public class AcceptOfferTest : TestBase
{
    public async Task AcceptOffer_Test()
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

        await RecruitmentModule.ExecuteCommandAsync(new AcceptOfferCommand(offerId));

        var offerDetails = await RecruitmentModule.ExecuteQueryAsync(new GetOfferDetailsQuery(offerId));

        // Assert
        Assert.That(offerDetails, Is.Not.Null);
        Assert.Equals(offerDetails.StatusName, OfferStatus.Accepted.ToString());
    }
}