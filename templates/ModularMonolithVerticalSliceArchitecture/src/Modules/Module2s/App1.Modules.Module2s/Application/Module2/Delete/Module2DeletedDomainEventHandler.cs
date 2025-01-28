using App1.Common.Application.Messaging;

namespace App1.Modules.Module2s.Application.Module2.Delete;

internal sealed class Module2DeletedDomainEventHandler()
	: DomainEventHandler<Module2DeletedDomainEvent>
{
	public override Task Handle(Module2DeletedDomainEvent domainEvent, CancellationToken cancellationToken = default)
	{
		return Task.CompletedTask;
	}
}