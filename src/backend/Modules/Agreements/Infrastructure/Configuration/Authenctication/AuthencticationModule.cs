using LinkedChain.Modules.Agreements.Application.Users;
using LinkedChain.Modules.Agreements.Domain.Users;
using Microsoft.Extensions.DependencyInjection;

namespace LinkedChain.Modules.Agreements.Infrastructure.Configuration.Authenctication;

public static class AuthenticationModule
{
    public static IServiceCollection AddAuthenticationModule(this IServiceCollection services)
    {
        services.AddScoped<IUserContext, UserContext>();

        return services;
    }
}