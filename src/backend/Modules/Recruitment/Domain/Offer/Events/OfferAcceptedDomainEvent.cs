﻿using LinkedChain.BuildingBlocks.Domain.Events;

namespace LinkedChain.Modules.Recruitment.Domain.Offer.Events;

public class OfferAcceptedDomainEvent : DomainEventBase
{
    public OfferId OfferId { get; }

    public Guid EmployeeId { get; }

    public Guid EmployerId { get; }

    public string ContractType { get; }

    public string SalaryPeriod { get; }

    public string SalaryCurrency { get; }

    public decimal SalaryAmount { get; }

    public DateTime StartDate { get; }

    public DateTime? EndDate { get; }

    public OfferAcceptedDomainEvent(
        OfferId offerId,
        Guid employeeId,
        Guid employerId,
        string contractType,
        string salaryPeriod,
        string salaryCurrency,
        decimal salaryAmount,
        DateTime startDate,
        DateTime? endDate)
    {
        OfferId = offerId;
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