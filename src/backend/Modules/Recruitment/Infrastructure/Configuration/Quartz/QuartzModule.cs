using Microsoft.Extensions.DependencyInjection;
using Quartz;
using System.Reflection;

namespace LinkedChain.Modules.Recruitment.Infrastructure.Configuration.Quartz;

public static class QuartzModule
{
    public static IServiceCollection AddQuartzJobs(this IServiceCollection services, Assembly assembly)
    {
        var jobTypes = assembly.GetTypes().Where(x => typeof(IJob).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract);

        foreach (var jobType in jobTypes)
        {
            services.AddTransient(typeof(IJob), jobType);
        }

        return services;
    }
}