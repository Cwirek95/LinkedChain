using LinkedChain.Modules.Recruitment.ArchTests.SeedWork;
using NetArchTest.Rules;
using NUnit.Framework;

namespace LinkedChain.Modules.Recruitment.ArchTests.Module;

[TestFixture]
public class LayersTests : TestBase
{
    [Test]
    public void DomainLayer_DoesNotHaveDependency_ToApplicationLayer()
    {
        var result = Types.InAssembly(DomainAssembly)
            .Should()
            .NotHaveDependencyOn(ApplicationAssembly.GetName().Name)
            .GetResult();

        AssertArchTestResult(result);
    }

    [Test]
    public void DomainLayer_DoesNotHaveDependency_ToInfrastructureLayer()
    {
        var result = Types.InAssembly(DomainAssembly)
            .Should()
            .NotHaveDependencyOn(ApplicationAssembly.GetName().Name)
            .GetResult();

        AssertArchTestResult(result);
    }
}