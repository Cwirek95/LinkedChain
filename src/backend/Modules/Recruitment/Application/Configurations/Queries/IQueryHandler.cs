using LinkedChain.Modules.Recruitment.Application.Contracts;
using MediatR;

namespace LinkedChain.Modules.Recruitment.Application.Configurations.Queries;

public interface IQueryHandler<in TQuery, TResult> :
    IRequestHandler<TQuery, TResult>
    where TQuery : IQuery<TResult>
{
}