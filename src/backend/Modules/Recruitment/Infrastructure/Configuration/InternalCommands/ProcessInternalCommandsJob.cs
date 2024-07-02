using LinkedChain.Modules.Recruitment.Infrastructure.Configuration.Processing;
using Quartz;

namespace LinkedChain.Modules.Recruitment.Infrastructure.Configuration.InternalCommands;

[DisallowConcurrentExecution]
public class ProcessInternalCommandsJob : IJob
{
    public async Task Execute(IJobExecutionContext context)
    {
        await CommandsExecutor.Execute(new ProcessInternalCommandsCommand());
    }
}