using App1.Common.Application.EventBus;
using App1.Common.Application.Exceptions;
using App1.Common.Application.Messaging;
using App1.Modules.Module1s.Infrastructure.Database;
using App1.Modules.Module1s.IntegrationEvents;
using Microsoft.EntityFrameworkCore;

namespace App1.Modules.Module1s.Application.Update;

internal sealed class Module1UpdatedDomainEventHandler(Module1sDbContext context, IEventBus bus)
	: DomainEventHandler<Module1UpdatedDomainEvent>
{
	public override async Task Handle(Module1UpdatedDomainEvent domainEvent,
		CancellationToken cancellationToken = default)
	{
		var result = await context.Module1s.FirstOrDefaultAsync(x => x.Id == domainEvent.Module1Id, cancellationToken);

		if (result is null)
		{
			throw new App1Exception(nameof(Module1UpdatedDomainEventHandler), Module1Errors.NotFound(domainEvent.Module1Id));
		}

		await bus.PublishAsync(
			new Module1UpdatedIntegrationEvent(domainEvent.Id, domainEvent.OccurredOnUtc, result.Id),
			cancellationToken);
	}
}