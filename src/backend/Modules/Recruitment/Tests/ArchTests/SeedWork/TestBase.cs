using System.Reflection;
using LinkedChain.Modules.Recruitment.Application.Contracts;
using LinkedChain.Modules.Recruitment.Domain.Offer;
using NetArchTest.Rules;
using NUnit.Framework;

namespace LinkedChain.Modules.Recruitment.ArchTests.SeedWork;

public abstract class TestBase
{
    protected static Assembly ApplicationAssembly => typeof(CommandBase).Assembly;

    protected static Assembly DomainAssembly => typeof(Offer).Assembly;
    
    protected static void AssertAreImmutable(IEnumerable<Type> types)
    {
        List<Type> failingTypes = new();
        foreach (var type in types)
        {
            if (type.GetFields().Any(x => !x.IsInitOnly) || type.GetProperties().Any(x => x.CanWrite))
            {
                failingTypes.Add(type);
                break;
            }
        }

        AssertFailingTypes(failingTypes);
    }

    protected static void AssertFailingTypes(IEnumerable<Type> types)
    {
        Assert.That(types, Is.Null.Or.Empty);
    }

    protected static void AssertArchTestResult(TestResult result)
    {
        AssertFailingTypes(result.FailingTypes);
    }
}