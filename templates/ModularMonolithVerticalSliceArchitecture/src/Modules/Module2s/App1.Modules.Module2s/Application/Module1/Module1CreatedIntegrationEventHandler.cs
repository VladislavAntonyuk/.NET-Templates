using App1.Common.Application.EventBus;
using App1.Modules.Module1s.IntegrationEvents;
using App1.Modules.Module2s.Infrastructure.Database;

namespace App1.Modules.Module2s.Application.Module1;

internal sealed class Module1CreatedIntegrationEventHandler(Module2sDbContext context)
	: IntegrationEventHandler<Module1CreatedIntegrationEvent>
{
	public override async Task Handle(Module1CreatedIntegrationEvent integrationEvent, CancellationToken cancellationToken = default)
	{
		var module2 = Module2.Module2.Create(integrationEvent.Module1Id);
		context.Add(module2);
		await context.SaveChangesAsync(cancellationToken);
	}
}