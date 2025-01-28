using App1.Common.Application.EventBus;
using App1.Common.Application.Exceptions;
using App1.Modules.Module1s.IntegrationEvents;
using App1.Modules.Module2s.Application.Module2s.CreateModule2;
using MediatR;

namespace App1.Modules.Module2s.Presentation.Module1s;

internal sealed class Module1CreatedIntegrationEventHandler(ISender sender)
	: IntegrationEventHandler<Module1CreatedIntegrationEvent>
{
	public override async Task Handle(Module1CreatedIntegrationEvent integrationEvent, CancellationToken cancellationToken = default)
	{
		var result = await sender.Send(new CreateModule2Command(integrationEvent.Module1Id), cancellationToken);

		if (result.IsFailure)
		{
			throw new App1Exception(nameof(CreateModule2Command), result.Error);
		}
	}
}