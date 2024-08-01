namespace LinkedChain.BuildingBlocks.IntegrationTests.Probing;

public class AssertErrorException : Exception
{
    public AssertErrorException(string message)
        : base(message)
    {
    }
}