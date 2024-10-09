using LinkedChain.Modules.Agreements.Application.Contracts;
using MediatR;

namespace LinkedChain.Modules.Agreements.Application.Configurations.Commands;

public interface ICommandHandler<in TCommand> : IRequestHandler<TCommand>
    where TCommand : ICommand
{
}

public interface ICommandHandler<in TCommand, TResult> :
    IRequestHandler<TCommand, TResult>
    where TCommand : ICommand<TResult>
{
}