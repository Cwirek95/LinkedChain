using LinkedChain.BuildingBlocks.Application.DataAccess;
using LinkedChain.BuildingBlocks.Infrastructure.Converters;
using LinkedChain.BuildingBlocks.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace LinkedChain.Modules.Agreements.Infrastructure.Configuration.DataAccess;

public static class DataAccessModule
{
    public static IServiceCollection AddDataAccessModule(this IServiceCollection services, string databaseConnectionString, ILoggerFactory loggerFactory)
    {
        services.AddScoped<ISqlConnectionFactory>(provider => new SqlConnectionFactory(databaseConnectionString));

        services.AddDbContext<AgreementsContext>(options =>
        {
            options.UseSqlServer(databaseConnectionString);
            options.ReplaceService<IValueConverterSelector, StronglyTypedIdValueConverterSelector>();
        });

        services.AddSingleton(loggerFactory);

        var infrastructureAssembly = typeof(AgreementsContext).Assembly;
        var repositoryTypes = infrastructureAssembly.GetTypes()
            .Where(type => type.Name.EndsWith("Repository") && type.IsClass && !type.IsAbstract);

        foreach (var type in repositoryTypes)
        {
            var implementedInterfaces = type.GetInterfaces();
            foreach (var implementedInterface in implementedInterfaces)
            {
                services.AddScoped(implementedInterface, type);
            }
        }

        return services;
    }
}