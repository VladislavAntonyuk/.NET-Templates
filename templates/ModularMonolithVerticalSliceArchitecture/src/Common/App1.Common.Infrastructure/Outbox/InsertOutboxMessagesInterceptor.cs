namespace App1.Common.Infrastructure.Outbox;

using System.Text.Json;
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Serialization;

public sealed class InsertOutboxMessagesInterceptor : SaveChangesInterceptor
{
	public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData,
		InterceptionResult<int> result,
		CancellationToken cancellationToken = default)
	{
		if (eventData.Context is not null)
		{
			InsertOutboxMessages(eventData.Context);
		}

		return base.SavingChangesAsync(eventData, result, cancellationToken);
	}

	private static void InsertOutboxMessages(DbContext context)
	{
		var outboxMessages = context.ChangeTracker.Entries<Entity>()
		                            .Select(entry => entry.Entity)
		                            .SelectMany(entity =>
		                            {
			                            var domainEvents = entity.DomainEvents;

			                            entity.ClearDomainEvents();

			                            return domainEvents;
		                            })
		                            .Select(static domainEvent => new OutboxMessage
		                            {
			                            Id = domainEvent.Id,
			                            Content = JsonSerializer.Serialize(domainEvent, SerializerSettings.Instance),
										OccurredOnUtc = domainEvent.OccurredOnUtc
		                            })
		                            .ToList();

		context.Set<OutboxMessage>().AddRange(outboxMessages);
	}
}