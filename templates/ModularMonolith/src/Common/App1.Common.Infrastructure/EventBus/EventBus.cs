namespace App1.Common.Infrastructure.EventBus;

using Application.EventBus;
using MassTransit;

internal sealed class EventBus(IBus bus) : IEventBus
{
	public async Task PublishAsync<T>(T integrationEvent, CancellationToken cancellationToken = default)
		where T : IIntegrationEvent
	{
		await bus.Publish(integrationEvent, cancellationToken);
	}
}