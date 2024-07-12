using LinkedChain.Modules.Recruitment.Domain.Offer;

namespace LinkedChain.Modules.Recruitment.Infrastructure.Domain;

internal class OfferRepository : IOfferRepository
{
    private readonly RecruitmentContext _context;

    public OfferRepository(RecruitmentContext context)
    {
        _context = context;
    }

    public async Task<Offer?> GetByIdAsync(OfferId id)
    {
        return await _context.Offers.FindAsync(id);
    }

    public async Task AddAsync(Offer offer)
    {
        await _context.Offers.AddAsync(offer);
    }
}