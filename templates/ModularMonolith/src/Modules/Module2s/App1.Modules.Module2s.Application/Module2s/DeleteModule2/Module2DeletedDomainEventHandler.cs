using App1.Common.Application.EventBus;
using App1.Common.Application.Messaging;
using App1.Modules.Module2s.Domain.Module2s;
using App1.Modules.Module2s.IntegrationEvents;

namespace App1.Modules.Module2s.Application.Module2s.DeleteModule2;

internal sealed class Module2DeletedDomainEventHandler(IEventBus eventBus) : DomainEventHandler<Module2DeletedDomainEvent>
{
	public override async Task Handle(Module2DeletedDomainEvent domainEvent, CancellationToken cancellationToken = default)
	{
		await eventBus.PublishAsync(
			new Module2DeletedIntegrationEvent(domainEvent.Id, domainEvent.OccurredOnUtc, domainEvent.Module2Id),
			cancellationToken);
	}
}