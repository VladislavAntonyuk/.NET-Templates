using App1.Common.Application.EventBus;
using App1.Common.Application.Messaging;
using App1.Modules.Module2s.Domain.Module2s;
using App1.Modules.Module2s.IntegrationEvents;

namespace App1.Modules.Module2s.Application.Module2s.UpdateModule2;

internal sealed class Module2UpdatedDomainEventHandler(IEventBus eventBus)
	: DomainEventHandler<Module2UpdatedDomainEvent>
{
	public override async Task Handle(Module2UpdatedDomainEvent domainEvent,
		CancellationToken cancellationToken = default)
	{
		await eventBus.PublishAsync(
			new Module2UpdatedIntegrationEvent(domainEvent.Id, domainEvent.OccurredOnUtc, domainEvent.Module2Id), cancellationToken);
	}
}