using Microsoft.Extensions.DependencyInjection;

namespace LinkedChain.Modules.Recruitment.Infrastructure.Configuration;

internal static class RecruitmentsCompositionRoot
{
    private static IServiceProvider _serviceProvider;

    internal static void SetServiceProvider(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    internal static IServiceScope BeginLifetimeScope()
    {
        if (_serviceProvider == null)
        {
            throw new InvalidOperationException("ServiceProvider is not set. Call SetServiceProvider first.");
        }
        
        return _serviceProvider.CreateScope();
    }
}