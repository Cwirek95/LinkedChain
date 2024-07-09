using LinkedChain.Modules.Recruitment.Application.Contracts;
using LinkedChain.Modules.Recruitment.Infrastructure.Configuration;
using LinkedChain.Modules.Recruitment.Infrastructure.Configuration.Processing;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace LinkedChain.Modules.Recruitment.Infrastructure;

public class RecruitmentModule : IRecruitmentModule
{
    public async Task<TResult> ExecuteCommandAsync<TResult>(ICommand<TResult> command)
    {
        return await CommandsExecutor.Execute(command);
    }

    public async Task ExecuteCommandAsync(ICommand command)
    {
        await CommandsExecutor.Execute(command);
    }

    public async Task<TResult> ExecuteQueryAsync<TResult>(IQuery<TResult> query)
    {
        using (var scope = RecruitmentsCompositionRoot.BeginLifetimeScope())
        {
            var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();

            return await mediator.Send(query);
        }
    }
}