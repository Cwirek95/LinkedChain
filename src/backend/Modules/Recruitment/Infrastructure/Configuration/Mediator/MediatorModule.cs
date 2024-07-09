using FluentValidation;
using LinkedChain.Modules.Recruitment.Application.Configurations.Commands;
using MediatR.Pipeline;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using LinkedChain.BuildingBlocks.Infrastructure.Common;

namespace LinkedChain.Modules.Recruitment.Infrastructure.Configuration;

public static class MediatorModule
{
    public static IServiceCollection AddMediationModule(this IServiceCollection services, params Assembly[] assemblies)
    {
        services.AddTransient<IServiceProvider, ServiceProviderWrapper>();
        services.AddMediatR(x => x.RegisterServicesFromAssemblies(assemblies));

        var mediatorOpenTypes = new[]
        {
            typeof(IRequestHandler<,>),
            typeof(INotificationHandler<>),
            typeof(IValidator<>),
            typeof(IRequestPreProcessor<>),
            typeof(IRequestHandler<>),
            typeof(IStreamRequestHandler<,>),
            typeof(IRequestPostProcessor<,>),
            typeof(IRequestExceptionHandler<,,>),
            typeof(IRequestExceptionAction<,>),
            typeof(ICommandHandler<>),
            typeof(ICommandHandler<,>),
        };

        foreach (var mediatorOpenType in mediatorOpenTypes)
        {
            RegisterClosedTypes(services, mediatorOpenType, assemblies);
        }

        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestPostProcessorBehavior<,>));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestPreProcessorBehavior<,>));

        return services;
    }

    private static void RegisterClosedTypes(IServiceCollection services, Type openGenericType, Assembly[] assemblies)
    {
        var types = assemblies.SelectMany(a => a.GetTypes())
                              .Where(t => !t.IsAbstract && !t.IsInterface)
                              .Select(t => new { Type = t, Interfaces = t.GetInterfaces() })
                              .SelectMany(t => t.Interfaces,
                                          (t, i) => new { t.Type, Interface = i })
                              .Where(t => t.Interface.IsGenericType &&
                                          t.Interface.GetGenericTypeDefinition() == openGenericType)
                              .ToList();

        foreach (var type in types)
        {
            services.AddTransient(type.Interface, type.Type);
        }
    }
}