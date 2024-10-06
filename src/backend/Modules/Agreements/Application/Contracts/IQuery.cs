using MediatR;

namespace LinkedChain.Modules.Agreements.Application.Contracts;

public interface IQuery<out TResult> : IRequest<TResult>
{
}