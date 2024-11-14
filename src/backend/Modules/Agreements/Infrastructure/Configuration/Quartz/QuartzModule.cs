using Microsoft.Extensions.DependencyInjection;
using Quartz;
using System.Reflection;

namespace LinkedChain.Modules.Agreements.Infrastructure.Configuration.Quartz;

public static class QuartzModule
{
    public static IServiceCollection AddQuartzModule(this IServiceCollection services, Assembly assembly)
    {
        var jobTypes = assembly.GetTypes().Where(x => typeof(IJob).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract);

        foreach (var jobType in jobTypes)
        {
            services.AddTransient(typeof(IJob), jobType);
        }

        return services;
    }
}