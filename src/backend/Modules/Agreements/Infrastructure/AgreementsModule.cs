using LinkedChain.Modules.Agreements.Application.Contracts;
using LinkedChain.Modules.Agreements.Infrastructure.Configuration;
using LinkedChain.Modules.Agreements.Infrastructure.Configuration.Processing;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace LinkedChain.Modules.Agreements.Infrastructure;

public class AgreementsModule : IAgreementsModule
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
        using (var scope = AgreementsCompositionRoot.BeginLifetimeScope())
        {
            var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();

            return await mediator.Send(query);
        }
    }
}