using LinkedChain.BuildingBlocks.Domain;

namespace LinkedChain.Modules.Recruitment.Domain.Offer;

public class ContractType : ValueObject
{
    public static ContractType Permanent => new ContractType(nameof(Permanent));
    public static ContractType Mandate => new ContractType(nameof(Mandate));
    public static ContractType B2B => new ContractType(nameof(B2B));
    
    public string Type { get; }

    private ContractType(string type)
    {
        Type = type;
    }

    public static ContractType Of(string type)
    {
        return new ContractType(type);
    }
}