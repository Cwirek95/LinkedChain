using LinkedChain.Modules.Recruitment.Application.Contracts;
using LinkedChain.Modules.Recruitment.Infrastructure.Configuration.Processing;

namespace LinkedChain.Modules.Recruitment.Infrastructure.Configuration.Outbox;

public class ProcessOutboxCommand : CommandBase, IRecurringCommand
{
}