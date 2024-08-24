namespace LinkedChain.Modules.Recruitment.Application.Offers.GetOfferDetails;

public class OfferDetailsDto
{
    public Guid Id { get; set; }

    public Guid EmployeeId { get; set; }

    public Guid EmployerId { get; set; }

    public string Description { get; set; }

    public string StatusName { get; set; }

    public string ContractType { get; set; }

    public string SalaryPeriod { get; set; }

    public string SalaryCurrency { get; set; }

    public decimal SalaryAmount { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime? EndDate { get; set; }
}