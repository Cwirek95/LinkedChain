namespace LinkedChain.BuildingBlocks.Infrastructure.Common;

public class ServiceProviderWrapper : IServiceProvider
{
    private readonly IServiceProvider _provider;

    public ServiceProviderWrapper(IServiceProvider provider)
    {
        _provider = provider;
    }

    public object? GetService(Type serviceType)
    {
        return _provider.GetService(serviceType);
    }
}