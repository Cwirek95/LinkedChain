using LinkedChain.Modules.Agreements.Infrastructure.Configuration.Processing;
using Quartz;

namespace LinkedChain.Modules.Agreements.Infrastructure.Configuration.InternalCommands;

[DisallowConcurrentExecution]
public class ProcessInternalCommandsJob : IJob
{
    public async Task Execute(IJobExecutionContext context)
    {
        await CommandsExecutor.Execute(new ProcessInternalCommands());
    }
}