using App1.Common.Application.EventBus;
using App1.Common.Application.Messaging;
using App1.Modules.Module1s.Domain.Module1s;
using App1.Modules.Module1s.IntegrationEvents;

namespace App1.Modules.Module1s.Application.Module1s.DeleteModule1;

internal sealed class Module1DeletedDomainEventHandler(IEventBus eventBus) : DomainEventHandler<Module1DeletedDomainEvent>
{
	public override async Task Handle(Module1DeletedDomainEvent domainEvent, CancellationToken cancellationToken = default)
	{
		await eventBus.PublishAsync(
			new Module1DeletedIntegrationEvent(domainEvent.Id, domainEvent.OccurredOnUtc, domainEvent.Module1Id),
			cancellationToken);
	}
}