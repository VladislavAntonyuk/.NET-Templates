using App1.Modules.Module2s.Domain.Module2s;
using App1.Modules.Module2s.UnitTests.Abstractions;

namespace App1.Modules.Module2s.UnitTests.Module2s;

public class Module2Tests : BaseTest
{
	[Fact]
	public void Create_ShouldReturnModule2()
	{
		// Act
		var module2 = Module2.Create(Guid.NewGuid());

		// Assert
		Assert.NotNull(module2);
	}

	[Fact]
	public void Create_ShouldRaiseDomainEvent_WhenModule2Created()
	{
		// Act
		var module2 = Module2.Create(Guid.NewGuid());

		// Assert
		var domainEvent = AssertDomainEventWasPublished<Module2CreatedDomainEvent>(module2);

		Assert.Equal(domainEvent.Module2Id, module2.Id);
	}

	[Fact]
	public void Update_ShouldRaiseDomainEvent_WhenModule2Updated()
	{
		// Arrange
		var module2 = Module2.Create(Guid.NewGuid());

		// Act
		module2.Update();

		// Assert
		var domainEvent = AssertDomainEventWasPublished<Module2UpdatedDomainEvent>(module2);

		Assert.Equal(domainEvent.Module2Id, module2.Id);
	}

	[Fact]
	public void Update_ShouldNotRaiseDomainEvent_WhenModule2NotUpdated()
	{
		// Arrange
		var module2 = Module2.Create(Guid.NewGuid());

		module2.ClearDomainEvents();

		// Act
		module2.Update();

		// Assert
		Assert.Empty(module2.DomainEvents);
	}
}