using App1.Common.Application.EventBus;
using App1.Common.Application.Exceptions;
using App1.Modules.Module1s.IntegrationEvents;
using App1.Modules.Module2s.Application.Module2s.UpdateModule2;
using MediatR;

namespace App1.Modules.Module2s.Presentation.Module1s;

internal sealed class Module1UpdatedIntegrationEventHandler(ISender sender)
	: IntegrationEventHandler<Module1UpdatedIntegrationEvent>
{
	public override async Task Handle(Module1UpdatedIntegrationEvent integrationEvent, CancellationToken cancellationToken = default)
	{
		var result = await sender.Send(new UpdateModule2Command(integrationEvent.Module1Id), cancellationToken);

		if (result.IsFailure)
		{
			throw new App1Exception(nameof(UpdateModule2Command), result.Error);
		}
	}
}