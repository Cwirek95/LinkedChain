using LinkedChain.Modules.Agreements.Infrastructure.Configuration.Processing;
using Quartz;

namespace LinkedChain.Modules.Agreements.Infrastructure.Configuration.Inbox;

[DisallowConcurrentExecution]
public class ProcessInboxJob : IJob
{
    public async Task Execute(IJobExecutionContext context)
    {
        await CommandsExecutor.Execute(new ProcessInboxCommand());
    }
}