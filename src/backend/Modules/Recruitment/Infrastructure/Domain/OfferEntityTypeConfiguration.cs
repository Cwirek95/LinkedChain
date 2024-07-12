using LinkedChain.Modules.Recruitment.Domain.Offer;
using LinkedChain.Modules.Recruitment.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LinkedChain.Modules.Recruitment.Infrastructure.Domain;

internal class OfferEntityTypeConfiguration : IEntityTypeConfiguration<Offer>
{
    public void Configure(EntityTypeBuilder<Offer> builder)
    {
        builder.ToTable("Offers", "recruitment");

        builder.HasKey(x => x.Id);

        builder.Property<UserId>("_employee").HasColumnName("Employee");
        builder.Property<UserId>("_employer").HasColumnName("Employer");
        builder.Property<string>("_description").HasColumnName("Description");
        builder.Property<DateTime>("_createDate").HasColumnName("CreateDate");
        builder.Property<DateTime>("_expirationDate").HasColumnName("ExpirationDate");

        builder.OwnsOne<OfferStatus>("_status", x =>
        {
            x.Property(p => p.Code).HasColumnName("Status");
        });

        builder.OwnsOne<ContractType>("_contractType", x =>
        {
            x.Property(p => p.Type).HasColumnName("ContractType");
        });

        builder.OwnsOne<ContractDuration>("_contractDuration", x =>
        {
            x.Property(p => p.StartDate).HasColumnName("ContractStartDate");
            x.Property(p => p.EndDate).HasColumnName("ContractEndDate");
        });

        builder.OwnsOne<Salary>("_salary", x =>
        {
            x.OwnsOne<PayPeriod>(p => p.Period, x =>
            {
                x.Property(p => p.Period).HasColumnName("SalaryPeriod");
            });
            x.Property(p => p.Currency).HasColumnName("SalaryCurrency");
            x.Property(p => p.Amount).HasColumnName("SalaryAmount");
        });
    }
}