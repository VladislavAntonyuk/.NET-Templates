using App1.Common.Application.EventBus;
using App1.Common.Application.Messaging;
using App1.Modules.Module1s.Domain.Module1s;
using App1.Modules.Module1s.IntegrationEvents;

namespace App1.Modules.Module1s.Application.Module1s.UpdateModule1;

internal sealed class Module1UpdatedDomainEventHandler(IEventBus eventBus)
	: DomainEventHandler<Module1UpdatedDomainEvent>
{
	public override async Task Handle(Module1UpdatedDomainEvent domainEvent,
		CancellationToken cancellationToken = default)
	{
		await eventBus.PublishAsync(
			new Module1UpdatedIntegrationEvent(domainEvent.Id, domainEvent.OccurredOnUtc, domainEvent.Module1Id), cancellationToken);
	}
}