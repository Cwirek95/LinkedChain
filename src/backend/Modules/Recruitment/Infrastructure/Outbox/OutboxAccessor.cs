using LinkedChain.BuildingBlocks.Application.Outbox;

namespace LinkedChain.Modules.Recruitment.Infrastructure.Outbox;

public class OutboxAccessor : IOutbox
{
    private readonly RecruitmentContext _recruitmentContext;

    internal OutboxAccessor(RecruitmentContext recruitmentContext)
    {
        _recruitmentContext = recruitmentContext;
    }

    public void Add(OutboxMessage message)
    {
        _recruitmentContext.OutboxMessages.Add(message);
    }

    public Task Save()
    {
        return Task.CompletedTask;
    }
}