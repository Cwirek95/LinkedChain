using MediatR;

namespace LinkedChain.Modules.Recruitment.Application.Contracts;

public interface IQuery<out TResult> : IRequest<TResult>
{
}