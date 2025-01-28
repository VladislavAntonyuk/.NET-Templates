using App1.Common.Application.EventBus;
using App1.Modules.Module1s.IntegrationEvents;
using App1.Modules.Module2s.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace App1.Modules.Module2s.Application.Module1;

internal sealed class Module1DeletedIntegrationEventHandler(Module2sDbContext context)
	: IntegrationEventHandler<Module1DeletedIntegrationEvent>
{
	public override async Task Handle(Module1DeletedIntegrationEvent integrationEvent, CancellationToken cancellationToken = default)
	{
		var module2 = await context.Module2s.FirstOrDefaultAsync(x => x.Id == integrationEvent.Module1Id, cancellationToken);
		if (module2 is not null)
		{
			module2.Delete();
			context.Remove(module2);
			await context.SaveChangesAsync(cancellationToken);
		}
	}
}