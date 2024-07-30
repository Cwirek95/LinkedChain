using LinkedChain.BuildingBlocks.Application;

namespace LinkedChain.Modules.Recruitment.IntegrationTests.SeedWork;

public class ExecutionContextMock : IExecutionContextAccessor
{
    public ExecutionContextMock(Guid userId)
    {
        UserId = userId;
    }

    public Guid UserId { get; }

    public Guid CorrelationId { get; }

    public bool IsAvailable { get; }
}