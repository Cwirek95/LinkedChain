using FluentValidation;

namespace LinkedChain.Modules.Recruitment.Application.Offers.CreateB2BContractOffer;

public class CreateB2BContractOfferCommandValidator : AbstractValidator<CreateB2BContractOfferCommand>
{
    public CreateB2BContractOfferCommandValidator()
    {
        RuleFor(x => x.Description)
            .NotEmpty()
            .WithMessage("Offer description cannot be empty");
        
        RuleFor(x => x.EndDate)
            .GreaterThanOrEqualTo(x => x.StartDate)
            .When(x => x.EndDate.HasValue)
            .WithMessage("EndDate of the contract offer cannot be before StartDate");
        
        RuleFor(x => x.SalaryPayPeriodCode)
            .NotEmpty()
            .WithMessage("SalaryPayPeriodCode cannot be empty");
        
        RuleFor(x => x.SalaryCurrency)
            .NotEmpty()
            .WithMessage("SalaryCurrency cannot be empty");
        
        RuleFor(x => x.SalaryAmount)
            .GreaterThan(0)
            .WithMessage("SalaryAmount must be greater than zero");
    }
}