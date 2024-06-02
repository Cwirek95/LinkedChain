using LinkedChain.Modules.Recruitment.Application.Configurations.Commands;
using LinkedChain.Modules.Recruitment.Domain.Offer;
using LinkedChain.Modules.Recruitment.Domain.Users;

namespace LinkedChain.Modules.Recruitment.Application.Offers.CreateMandateContractOffer;

internal class CreateMandateContractOfferCommandHandler : ICommandHandler<CreateMandateContractOfferCommand, Guid>
{
    private readonly IOfferRepository _offerRepository;

    internal CreateMandateContractOfferCommandHandler(IOfferRepository offerRepository)
    {
        _offerRepository = offerRepository;
    }

    public async Task<Guid> Handle(CreateMandateContractOfferCommand request, CancellationToken cancellationToken)
    {
        var offer = Offer.CreateNew(
            new UserId(request.EmployeeId),
            new UserId(request.EmployerId),
            request.Description,
            ContractType.Mandate,
            request.EndDate is not null 
                ? ContractDuration.CreateNewBetweenDates(request.StartDate, request.EndDate.Value) 
                : ContractDuration.CreateNewIndefinitely(request.StartDate),
            Salary.Of(request.SalaryAmount, request.SalaryCurrency, PayPeriod.Of(request.SalaryPayPeriodCode)));

        await _offerRepository.AddAsync(offer);
        
        return offer.Id.Value;
    }
}