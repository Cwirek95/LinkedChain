namespace LinkedChain.Modules.Agreements.Domain.Agreement;

public class Salary
{
    public PayPeriod Period { get; }
    public string Currency { get; }
    public decimal Amount { get; }

    private Salary(decimal amount, string currency, PayPeriod period)
    {
        Amount = amount;
        Currency = currency;
        Period = period;
    }

    public static Salary Of(decimal amount, string currency, PayPeriod period)
    {
        return new Salary(amount, currency, period);
    }
}