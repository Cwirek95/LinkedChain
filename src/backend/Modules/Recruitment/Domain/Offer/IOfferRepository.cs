namespace LinkedChain.Modules.Recruitment.Domain.Offer;

public interface IOfferRepository
{
    Task<Offer> GetByIdAsync(OfferId id);

    Task AddAsync(Offer offer);
}