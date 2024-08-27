using LinkedChain.Modules.Recruitment.Application.Contracts;

namespace LinkedChain.Modules.Recruitment.Application.Offers.CreateB2BContractOffer;

public sealed class CreateB2BContractOfferCommand : CommandBase<Guid>
{
    public CreateB2BContractOfferCommand(
        Guid employeeId,
        Guid employerId,
        string description,
        DateTime startDate,
        DateTime? endDate,
        string salaryPayPeriodCode,
        string salaryCurrency,
        decimal salaryAmount)
    {
        EmployeeId = employeeId;
        EmployerId = employerId;
        Description = description;
        StartDate = startDate;
        EndDate = endDate;
        SalaryPayPeriodCode = salaryPayPeriodCode;
        SalaryCurrency = salaryCurrency;
        SalaryAmount = salaryAmount;
    }

    public Guid EmployeeId { get; }
    public Guid EmployerId { get; }
    public string Description { get; }
    public DateTime StartDate { get; }
    public DateTime? EndDate { get; }
    public string SalaryPayPeriodCode { get; }
    public string SalaryCurrency { get; }
    public decimal SalaryAmount { get; }
}