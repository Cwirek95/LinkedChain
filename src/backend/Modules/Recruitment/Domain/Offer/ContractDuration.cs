using LinkedChain.BuildingBlocks.Domain;
using LinkedChain.Modules.Recruitment.Domain.Offer.Rules;

namespace LinkedChain.Modules.Recruitment.Domain.Offer;

public class ContractDuration : ValueObject
{
    public DateTime StartDate { get; }
    public DateTime? EndDate { get; }
    
    private ContractDuration(DateTime startDate, DateTime? endDate)
    {
        StartDate = startDate;
        EndDate = endDate;
    }

    public static ContractDuration CreateNewBetweenDates(DateTime startDate, DateTime endDate)
    {
        CheckRule(new StartDateOfContractMustBeBeforeEndDateRule(startDate, endDate));
        
        return new ContractDuration(startDate, endDate);
    }
    
    public static ContractDuration CreateNewIndefinitely(DateTime startDate)
    {
        return new ContractDuration(startDate, null);
    }
}