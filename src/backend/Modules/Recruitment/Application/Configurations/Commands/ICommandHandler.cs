using LinkedChain.Modules.Recruitment.Application.Contracts;
using MediatR;

namespace LinkedChain.Modules.Recruitment.Application.Configurations.Commands;

public interface ICommandHandler<in TCommand> : IRequestHandler<TCommand>
    where TCommand : ICommand
{
}

public interface ICommandHandler<in TCommand, TResult> :
    IRequestHandler<TCommand, TResult>
    where TCommand : ICommand<TResult>
{
}