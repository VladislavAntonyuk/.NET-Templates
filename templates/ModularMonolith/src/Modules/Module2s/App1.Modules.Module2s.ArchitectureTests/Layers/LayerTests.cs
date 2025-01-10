using App1.Modules.Module2s.ArchitectureTests.Abstractions;
using NetArchTest.Rules;

namespace App1.Modules.Module2s.ArchitectureTests.Layers;

public class LayerTests : BaseTest
{
	[Fact]
	public void DomainLayer_ShouldNotHaveDependencyOn_ApplicationLayer()
	{
		Types.InAssembly(DomainAssembly)
		     .Should()
		     .NotHaveDependencyOn(ApplicationAssembly.GetName().Name)
		     .GetResult()
		     .ShouldBeSuccessful();
	}

	[Fact]
	public void DomainLayer_ShouldNotHaveDependencyOn_InfrastructureLayer()
	{
		Types.InAssembly(DomainAssembly)
		     .Should()
		     .NotHaveDependencyOn(InfrastructureAssembly.GetName().Name)
		     .GetResult()
		     .ShouldBeSuccessful();
	}

	[Fact]
	public void ApplicationLayer_ShouldNotHaveDependencyOn_InfrastructureLayer()
	{
		Types.InAssembly(ApplicationAssembly)
		     .Should()
		     .NotHaveDependencyOn(InfrastructureAssembly.GetName().Name)
		     .GetResult()
		     .ShouldBeSuccessful();
	}

	[Fact]
	public void ApplicationLayer_ShouldNotHaveDependencyOn_PresentationLayer()
	{
		Types.InAssembly(ApplicationAssembly)
		     .Should()
		     .NotHaveDependencyOn(PresentationAssembly.GetName().Name)
		     .GetResult()
		     .ShouldBeSuccessful();
	}

	[Fact]
	public void PresentationLayer_ShouldNotHaveDependencyOn_InfrastructureLayer()
	{
		Types.InAssembly(PresentationAssembly)
		     .Should()
		     .NotHaveDependencyOn(InfrastructureAssembly.GetName().Name)
		     .GetResult()
		     .ShouldBeSuccessful();
	}
}