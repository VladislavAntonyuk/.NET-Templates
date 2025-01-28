using System.Text.Json;
using App1.Common.Application.EventBus;
using App1.Common.Infrastructure.Inbox;
using App1.Common.Infrastructure.Serialization;
using App1.Modules.Module2s.Infrastructure.Database;
using MassTransit;

namespace App1.Modules.Module2s.Infrastructure.Inbox;

internal sealed class IntegrationEventConsumer<TIntegrationEvent>(Module2sDbContext dbContext)
	: IConsumer<TIntegrationEvent> where TIntegrationEvent : IntegrationEvent
{
	public async Task Consume(ConsumeContext<TIntegrationEvent> context)
	{
		var integrationEvent = context.Message;

		var inboxMessage = new InboxMessage
		{
			Id = integrationEvent.Id,
			Content = JsonSerializer.Serialize<IIntegrationEvent>(integrationEvent, SerializerSettings.Instance),
			OccurredOnUtc = integrationEvent.OccurredOnUtc
		};

		dbContext.InboxMessages.Add(inboxMessage);
		await dbContext.SaveChangesAsync();
	}
}