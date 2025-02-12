using App1.Modules.Module1s.Domain.Module1s;
using App1.Modules.Module1s.UnitTests.Abstractions;

namespace App1.Modules.Module1s.UnitTests.Module1s;

public class Module1Tests : BaseTest
{
	[Fact]
	public void Create_ShouldReturnModule1()
	{
		// Act
		var module1 = Module1.Create(Guid.NewGuid());

		// Assert
		Assert.NotNull(module1);
	}

	[Fact]
	public void Create_ShouldRaiseDomainEvent_WhenModule1Created()
	{
		// Act
		var module1 = Module1.Create(Guid.NewGuid());

		// Assert
		var domainEvent = AssertDomainEventWasPublished<Module1CreatedDomainEvent>(module1);

		Assert.Equal(domainEvent.Module1Id, module1.Id);
	}

	[Fact]
	public void Update_ShouldRaiseDomainEvent_WhenModule1Updated()
	{
		// Arrange
		var module1 = Module1.Create(Guid.NewGuid());

		// Act
		module1.Update();

		// Assert
		var domainEvent = AssertDomainEventWasPublished<Module1UpdatedDomainEvent>(module1);

		Assert.Equal(domainEvent.Module1Id, module1.Id);
	}

	[Fact]
	public void Update_ShouldNotRaiseDomainEvent_WhenModule1NotUpdated()
	{
		// Arrange
		var module1 = Module1.Create(Guid.NewGuid());

		module1.ClearDomainEvents();

		// Act
		module1.Update();

		// Assert
		Assert.Empty(module1.DomainEvents);
	}
}