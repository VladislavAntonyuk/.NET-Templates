using App1.Common.Domain;
using App1.Modules.Module1s.Application.Create;
using App1.Modules.Module1s.Application.Delete;
using App1.Modules.Module1s.Application.Update;

namespace App1.Modules.Module1s.Application;

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
			Id = id
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