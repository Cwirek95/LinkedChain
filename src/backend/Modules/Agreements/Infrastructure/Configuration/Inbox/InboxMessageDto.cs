namespace LinkedChain.Modules.Agreements.Infrastructure.Configuration.Inbox;

public class InboxMessageDto
{
    public Guid Id { get; set; }

    public string Type { get; set; }

    public string Data { get; set; }
}