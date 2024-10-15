using LinkedChain.Modules.Agreements.Application.Contracts;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace LinkedChain.Modules.Agreements.Infrastructure.Configuration.Processing;

internal static class CommandsExecutor
{
    internal static async Task Execute(ICommand command)
    {
        using (var scope = AgreementsCompositionRoot.BeginLifetimeScope())
        {
            var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();
            await mediator.Send(command);
        }
    }

    internal static async Task<TResult> Execute<TResult>(ICommand<TResult> command)
    {
        using (var scope = AgreementsCompositionRoot.BeginLifetimeScope())
        {
            var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();
            return await mediator.Send(command);
        }
    }
}