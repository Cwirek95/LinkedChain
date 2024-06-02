using LinkedChain.BuildingBlocks.Domain;

namespace LinkedChain.Modules.Recruitment.Domain.Offer.Rules;

public class StartDateOfContractMustBeBeforeEndDateRule : IBusinessRule
{
    private readonly DateTime _startDate;
    private readonly DateTime _endDate;

    public StartDateOfContractMustBeBeforeEndDateRule(DateTime startDate, DateTime endDate)
    {
        _startDate = startDate;
        _endDate = endDate;
    }
    
    public bool IsBroken() => _endDate < _startDate;

    public string Message => "EndDate of the contract offer cannot be before StartDate";
}