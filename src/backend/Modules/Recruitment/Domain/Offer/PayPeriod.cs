using LinkedChain.BuildingBlocks.Domain;

namespace LinkedChain.Modules.Recruitment.Domain.Offer;

public class PayPeriod : ValueObject
{
    public static PayPeriod Hourly => new PayPeriod(nameof(Hourly));
    public static PayPeriod Daily => new PayPeriod(nameof(Daily));
    public static PayPeriod Weekly => new PayPeriod(nameof(Weekly));
    public static PayPeriod Monthly => new PayPeriod(nameof(Monthly));
    public static PayPeriod Annually => new PayPeriod(nameof(Annually));
    
    public string Period { get; }
    
    private PayPeriod(string period)
    {
        Period = period;
    }

    public static PayPeriod Of(string code)
    {
        return new PayPeriod(code);
    }
}