using LinkedChain.BuildingBlocks.Application.Outbox;

namespace LinkedChain.Modules.Agreements.Infrastructure.Outbox;

public class OutboxAccessor : IOutbox
{
    private readonly AgreementsContext _agreementsContext;

    internal OutboxAccessor(AgreementsContext agreementsContext)
    {
        _agreementsContext = agreementsContext;
    }

    public void Add(OutboxMessage message)
    {
        _agreementsContext.OutboxMessages.Add(message);
    }

    public Task Save()
    {
        return Task.CompletedTask;
    }
}