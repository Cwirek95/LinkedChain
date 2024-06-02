using LinkedChain.Modules.Recruitment.Application.Configurations.Commands;
using LinkedChain.Modules.Recruitment.Domain.Offer;
using LinkedChain.Modules.Recruitment.Domain.Users;

namespace LinkedChain.Modules.Recruitment.Application.Offers.CreateB2BContractOffer;

internal class CreateB2BContractOfferCommandHandler : ICommandHandler<CreateB2BContractOfferCommand, Guid>
{
    private readonly IOfferRepository _offerRepository;

    internal CreateB2BContractOfferCommandHandler(IOfferRepository offerRepository)
    {
        _offerRepository = offerRepository;
    }

    public async Task<Guid> Handle(CreateB2BContractOfferCommand request, CancellationToken cancellationToken)
    {
        var offer = Offer.CreateNew(
            new UserId(request.EmployeeId),
            new UserId(request.EmployerId),
            request.Description,
            ContractType.B2B,
            request.EndDate is not null 
                ? ContractDuration.CreateNewBetweenDates(request.StartDate, request.EndDate.Value) 
                : ContractDuration.CreateNewIndefinitely(request.StartDate),
            Salary.Of(request.SalaryAmount, request.SalaryCurrency, PayPeriod.Of(request.SalaryPayPeriodCode)));

        await _offerRepository.AddAsync(offer);
        
        return offer.Id.Value;
    }
}