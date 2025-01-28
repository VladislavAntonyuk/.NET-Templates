using App1.Common.Application.Messaging;

namespace App1.Modules.Module2s.Application.Module2.Update;

internal sealed class Module2UpdatedDomainEventHandler()
	: DomainEventHandler<Module2UpdatedDomainEvent>
{
	public override Task Handle(Module2UpdatedDomainEvent domainEvent, CancellationToken cancellationToken = default)
	{
		return Task.CompletedTask;
	}
}