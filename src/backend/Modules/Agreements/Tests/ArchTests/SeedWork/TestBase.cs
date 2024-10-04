using LinkedChain.Modules.Agreements.Application.Contracts;
using LinkedChain.Modules.Agreements.Domain.Agreement;
using NetArchTest.Rules;
using NUnit.Framework;
using System.Reflection;

namespace LinkedChain.Modules.Agreements.Domain.ArchTests.SeedWork;

public abstract class TestBase
{
    protected static Assembly ApplicationAssembly => typeof(CommandBase).Assembly;

    protected static Assembly DomainAssembly => typeof(B2BAgreement).Assembly;

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