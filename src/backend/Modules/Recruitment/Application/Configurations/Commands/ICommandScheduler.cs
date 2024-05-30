using LinkedChain.Modules.Recruitment.Application.Contracts;

namespace LinkedChain.Modules.Recruitment.Application.Configurations.Commands;

public interface ICommandsScheduler
{
    Task EnqueueAsync(ICommand command);

    Task EnqueueAsync<T>(ICommand<T> command);
}