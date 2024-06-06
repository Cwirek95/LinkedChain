using FluentValidation;

namespace LinkedChain.Modules.Recruitment.Application.Offers.CreateMandateContractOffer;

internal class CreateMandateContractOfferCommandValidator : AbstractValidator<CreateMandateContractOfferCommand>
{
    public CreateMandateContractOfferCommandValidator()
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