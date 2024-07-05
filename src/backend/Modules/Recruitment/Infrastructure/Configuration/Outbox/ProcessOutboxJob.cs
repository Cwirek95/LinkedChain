using LinkedChain.Modules.Recruitment.Infrastructure.Configuration.Processing;
using Quartz;

namespace LinkedChain.Modules.Recruitment.Infrastructure.Configuration.Outbox;

[DisallowConcurrentExecution]
public class ProcessOutboxJob : IJob
{
    public async Task Execute(IJobExecutionContext context)
    {
        await CommandsExecutor.Execute(new ProcessOutboxCommand());
    }
}