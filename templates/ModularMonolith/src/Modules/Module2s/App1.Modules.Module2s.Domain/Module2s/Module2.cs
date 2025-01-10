﻿using App1.Common.Domain;

namespace App1.Modules.Module2s.Domain.Module2s;

public sealed class Module2 : Entity
{
	private Module2()
	{
	}

	public Guid Id { get; private init; }

	public static Module2 Create(Guid id)
	{
		var module2 = new Module2
		{
			Id = id,
		};

		module2.Raise(new Module2CreatedDomainEvent(module2.Id));

		return module2;
	}

	public void Update()
	{
		Raise(new Module2UpdatedDomainEvent(Id));
	}

	public void Delete()
	{
		Raise(new Module2DeletedDomainEvent(Id));
	}
}