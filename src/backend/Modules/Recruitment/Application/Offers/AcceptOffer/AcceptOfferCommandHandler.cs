using LinkedChain.Modules.Recruitment.Application.Configurations.Commands;
using LinkedChain.Modules.Recruitment.Domain.Offer;

namespace LinkedChain.Modules.Recruitment.Application.Offers.AcceptOffer;

internal class AcceptOfferCommandHandler : ICommandHandler<AcceptOfferCommand>
{
    private readonly IOfferRepository _offerRepository;

    public AcceptOfferCommandHandler(IOfferRepository offerRepository)
    {
        _offerRepository = offerRepository;
    }

    public async Task Handle(AcceptOfferCommand request, CancellationToken cancellationToken)
    {
        var offer = await _offerRepository.GetByIdAsync(new OfferId(request.OfferId));

        offer.Reject();
    }
}