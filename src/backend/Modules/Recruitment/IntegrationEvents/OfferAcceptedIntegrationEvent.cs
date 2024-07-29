using LinkedChain.BuildingBlocks.Infrastructure.EventBus;

namespace LinkedChain.Modules.Recruitment.IntegrationEvents;

public class OfferAcceptedIntegrationEvent : IntegrationEvent
{
    public Guid EmployeeId { get; }

    public Guid EmployerId { get; }

    public string ContractType { get; }

    public string SalaryPeriod { get; }

    public string SalaryCurrency { get; }

    public decimal SalaryAmount { get; }

    public DateTime StartDate { get; }

    public DateTime? EndDate { get; }

    public OfferAcceptedIntegrationEvent(
        Guid id,
        DateTime occurredOn,
        Guid employeeId,
        Guid employerId,
        string contractType,
        string salaryPeriod,
        string salaryCurrency,
        decimal salaryAmount,
        DateTime startDate,
        DateTime? endDate)
        : base(id, occurredOn)
    {
        EmployeeId = employeeId;
        EmployerId = employerId;
        ContractType = contractType;
        SalaryPeriod = salaryPeriod;
        SalaryCurrency = salaryCurrency;
        SalaryAmount = salaryAmount;
        StartDate = startDate;
        EndDate = endDate;
    }
}