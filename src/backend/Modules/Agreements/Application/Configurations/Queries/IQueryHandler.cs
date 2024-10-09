using LinkedChain.Modules.Agreements.Application.Contracts;
using MediatR;

namespace LinkedChain.Modules.Agreements.Application.Configurations.Queries;

public interface IQueryHandler<in TQuery, TResult> :
    IRequestHandler<TQuery, TResult>
    where TQuery : IQuery<TResult>
{
}