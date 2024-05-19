using LinkedChain.BuildingBlocks.Domain;
using LinkedChain.Modules.Recruitment.Domain.SharedKernel;

namespace LinkedChain.Modules.Recruitment.Domain.Offer.Rules;

public class DurationOfContractMustBeDefinedStartDateRule : IBusinessRule
{
    private readonly ContractDuration _contractDuration;

    public DurationOfContractMustBeDefinedStartDateRule(ContractDuration contractDuration)
    {
        _contractDuration = contractDuration;
    }

    public bool IsBroken() => _contractDuration is ContractDuration { StartDate: DateTime };

    public string Message => "StartDate of the contract duration must be defined.";
}