using LinkedChain.Modules.Agreements.Application.Contracts;

namespace LinkedChain.Modules.Agreements.Application.Configurations.Commands;

public interface ICommandsScheduler
{
    Task EnqueueAsync(ICommand command);

    Task EnqueueAsync<T>(ICommand<T> command);
}