using App1.Common.Domain;
using AutoFixture;

namespace App1.Modules.Module1s.UnitTests.Abstractions;

public abstract class BaseTest
{
	protected static readonly Fixture Faker = new();

	public static T AssertDomainEventWasPublished<T>(Entity entity) where T : IDomainEvent
	{
		var domainEvent = entity.DomainEvents.OfType<T>().SingleOrDefault();

		if (domainEvent is null)
		{
			throw new Exception($"{typeof(T).Name} was not published");
		}

		return domainEvent;
	}
}