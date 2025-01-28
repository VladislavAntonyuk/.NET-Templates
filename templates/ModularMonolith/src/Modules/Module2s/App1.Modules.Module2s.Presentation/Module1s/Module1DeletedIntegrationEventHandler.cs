using App1.Common.Application.EventBus;
using App1.Common.Application.Exceptions;
using App1.Modules.Module1s.IntegrationEvents;
using App1.Modules.Module2s.Application.Module2s.DeleteModule2;
using MediatR;

namespace App1.Modules.Module2s.Presentation.Module1s;

internal sealed class Module1DeletedIntegrationEventHandler(ISender sender)
	: IntegrationEventHandler<Module1DeletedIntegrationEvent>
{
	public override async Task Handle(Module1DeletedIntegrationEvent integrationEvent, CancellationToken cancellationToken = default)
	{
		var result = await sender.Send(new DeleteModule2Command(integrationEvent.Module1Id), cancellationToken);

		if (result.IsFailure)
		{
			throw new App1Exception(nameof(DeleteModule2Command), result.Error);
		}
	}
}