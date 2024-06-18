using LinkedChain.Modules.Recruitment.Application.Users;
using LinkedChain.Modules.Recruitment.Domain.Users;
using Microsoft.Extensions.DependencyInjection;

namespace LinkedChain.Modules.Recruitment.Infrastructure.Configuration.Authentication;

public static class AuthenticationModule
{
    public static IServiceCollection AddAuthenticationModule(this IServiceCollection services)
    {
        services.AddScoped<IUserContext, UserContext>();
        
        return services;
    }
}