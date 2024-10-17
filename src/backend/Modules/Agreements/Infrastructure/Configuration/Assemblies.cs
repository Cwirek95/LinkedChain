using LinkedChain.Modules.Agreements.Application.Contracts;
using System.Reflection;

namespace LinkedChain.Modules.Agreements.Infrastructure.Configuration;

internal static class Assemblies
{
    public static readonly Assembly Application = typeof(IAgreementsModule).Assembly;
}