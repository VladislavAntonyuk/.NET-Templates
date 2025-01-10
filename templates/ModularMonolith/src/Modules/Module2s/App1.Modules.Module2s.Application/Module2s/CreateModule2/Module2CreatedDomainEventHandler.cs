using App1.Common.Application.EventBus;
using App1.Common.Application.Exceptions;
using App1.Common.Application.Messaging;
using App1.Modules.Module2s.Application.Module2s.GetModule2ById;
using App1.Modules.Module2s.Domain.Module2s;
using App1.Modules.Module2s.IntegrationEvents;
using MediatR;

namespace App1.Modules.Module2s.Application.Module2s.CreateModule2;

internal sealed class Module2CreatedDomainEventHandler(ISender sender, IEventBus bus)
	: DomainEventHandler<Module2CreatedDomainEvent>
{
	public override async Task Handle(Module2CreatedDomainEvent domainEvent,
		CancellationToken cancellationToken = default)
	{
		var result = await sender.Send(new GetModule2Query(domainEvent.Module2Id), cancellationToken);

		if (result.IsFailure)
		{
			throw new App1Exception(nameof(GetModule2Query), result.Error);
		}

		await bus.PublishAsync(
			new Module2CreatedIntegrationEvent(domainEvent.Id, domainEvent.OccurredOnUtc, result.Value.Id),
			cancellationToken);
	}
}