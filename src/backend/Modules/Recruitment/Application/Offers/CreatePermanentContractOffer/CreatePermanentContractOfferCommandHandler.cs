using LinkedChain.Modules.Recruitment.Application.Configurations.Commands;
using LinkedChain.Modules.Recruitment.Domain.Offer;
using LinkedChain.Modules.Recruitment.Domain.Users;

namespace LinkedChain.Modules.Recruitment.Application.Offers.CreatePermanentContractOffer;

internal class CreatePermanentContractOfferCommandHandler : ICommandHandler<CreatePermanentContractOfferCommand, Guid>
{
    private readonly IOfferRepository _offerRepository;

    internal CreatePermanentContractOfferCommandHandler(IOfferRepository offerRepository)
    {
        _offerRepository = offerRepository;
    }


    public async Task<Guid> Handle(CreatePermanentContractOfferCommand request, CancellationToken cancellationToken)
    {
        var offer = Offer.CreateNew(
            new UserId(request.EmployeeId),
            new UserId(request.EmployerId),
            request.Description,
            ContractType.Permanent,
            request.EndDate is not null 
                ? ContractDuration.CreateNewBetweenDates(request.StartDate, request.EndDate.Value) 
                : ContractDuration.CreateNewIndefinitely(request.StartDate),
            Salary.Of(request.SalaryAmount, request.SalaryCurrency, PayPeriod.Of(request.SalaryPayPeriodCode)));

        await _offerRepository.AddAsync(offer);
        
        return offer.Id.Value;
    }
}