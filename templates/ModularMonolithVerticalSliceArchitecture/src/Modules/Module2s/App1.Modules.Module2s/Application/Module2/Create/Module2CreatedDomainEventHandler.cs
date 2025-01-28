using App1.Common.Application.Messaging;

namespace App1.Modules.Module2s.Application.Module2.Create;

internal sealed class Module2CreatedDomainEventHandler()
	: DomainEventHandler<Module2CreatedDomainEvent>
{
	public override Task Handle(Module2CreatedDomainEvent domainEvent,
		CancellationToken cancellationToken = default)
	{
		return Task.CompletedTask;
	}
}