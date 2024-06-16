using System.Reflection;
using LinkedChain.Modules.Recruitment.Application.Contracts;

namespace LinkedChain.Modules.Recruitment.Infrastructure.Configuration;

internal static class Assemblies
{
    public static readonly Assembly Application = typeof(IRecruitmentModule).Assembly;
}