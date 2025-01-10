using App1.Common.Application.EventBus;
using App1.Common.Application.Exceptions;
using App1.Common.Application.Messaging;
using App1.Modules.Module1s.Application.Module1s.GetModule1ById;
using App1.Modules.Module1s.Domain.Module1s;
using App1.Modules.Module1s.IntegrationEvents;
using MediatR;

namespace App1.Modules.Module1s.Application.Module1s.CreateModule1;

internal sealed class Module1CreatedDomainEventHandler(ISender sender, IEventBus bus)
	: DomainEventHandler<Module1CreatedDomainEvent>
{
	public override async Task Handle(Module1CreatedDomainEvent domainEvent,
		CancellationToken cancellationToken = default)
	{
		var result = await sender.Send(new GetModule1Query(domainEvent.Module1Id), cancellationToken);

		if (result.IsFailure)
		{
			throw new App1Exception(nameof(GetModule1Query), result.Error);
		}

		await bus.PublishAsync(
			new Module1CreatedIntegrationEvent(domainEvent.Id, domainEvent.OccurredOnUtc, result.Value.Id),
			cancellationToken);
	}
}