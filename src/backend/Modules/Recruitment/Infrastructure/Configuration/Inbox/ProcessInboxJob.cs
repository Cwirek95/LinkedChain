using LinkedChain.Modules.Recruitment.Infrastructure.Configuration.Processing;
using Quartz;

namespace LinkedChain.Modules.Recruitment.Infrastructure.Configuration.Inbox;

[DisallowConcurrentExecution]
public class ProcessInboxJob : IJob
{
    public async Task Execute(IJobExecutionContext context)
    {
        await CommandsExecutor.Execute(new ProcessInboxCommand());
    }
}