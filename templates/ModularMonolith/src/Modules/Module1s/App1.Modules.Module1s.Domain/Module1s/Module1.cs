using App1.Common.Domain;

namespace App1.Modules.Module1s.Domain.Module1s;

public sealed class Module1 : Entity
{
	private Module1()
	{
	}

	public Guid Id { get; private init; }

	public static Module1 Create(Guid id)
	{
		var module1 = new Module1
		{
			Id = id,
		};

		module1.Raise(new Module1CreatedDomainEvent(module1.Id));

		return module1;
	}

	public void Update()
	{
		Raise(new Module1UpdatedDomainEvent(Id));
	}

	public void Delete()
	{
		Raise(new Module1DeletedDomainEvent(Id));
	}
}