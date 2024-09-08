using LinkedChain.BuildingBlocks.Domain;

namespace LinkedChain.Modules.Agreements.Domain.Agreement;

public class AgreementDuration : ValueObject
{
    public DateTime StartDate { get; }
    public DateTime? EndDate { get; }

    private AgreementDuration(DateTime startDate, DateTime? endDate)
    {
        StartDate = startDate;
        EndDate = endDate;
    }

    public static AgreementDuration Create(DateTime startDate, DateTime? endDate)
    { 
        return new AgreementDuration(startDate, endDate);
    }
}