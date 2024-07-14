using LinkedChain.Modules.Recruitment.Application.Configurations.Commands;
using LinkedChain.Modules.Recruitment.Domain.Offer;

namespace LinkedChain.Modules.Recruitment.Application.Offers.RejectOffer;

internal class RejectOfferCommandHandler : ICommandHandler<RejectOfferCommand>
{
    private readonly IOfferRepository _offerRepository;

    public RejectOfferCommandHandler(IOfferRepository offerRepository)
    {
        _offerRepository = offerRepository;
    }

    public async Task Handle(RejectOfferCommand request, CancellationToken cancellationToken)
    {
        var offer = await _offerRepository.GetByIdAsync(new OfferId(request.OfferId));

        offer.Reject();
    }
}