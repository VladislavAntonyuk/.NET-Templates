using System.Text.Json;
using App1.Common.Application.Messaging;
using App1.Common.Domain;
using App1.Common.Infrastructure.Outbox;
using App1.Common.Infrastructure.Serialization;
using App1.Modules.Module1s.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Quartz;

namespace App1.Modules.Module1s.Infrastructure.Outbox;

[DisallowConcurrentExecution]
internal sealed class ProcessOutboxJob(
	Module1sDbContext dbContext,
	IServiceScopeFactory serviceScopeFactory,
	TimeProvider dateTimeProvider,
	IOptions<OutboxOptions> outboxOptions,
	ILogger<ProcessOutboxJob> logger) : IJob
{
	private const string ModuleName = "Module1s";

	public async Task Execute(IJobExecutionContext context)
	{
		logger.LogInformation("{Module} - Beginning to process outbox messages", ModuleName);

		var outboxMessages = await GetOutboxMessagesAsync();

		foreach (var outboxMessage in outboxMessages)
		{
			Exception? exception = null;

			try
			{
				var domainEvent = JsonSerializer.Deserialize<IDomainEvent>(outboxMessage.Content, SerializerSettings.Instance)!;

				using var scope = serviceScopeFactory.CreateScope();
				var handler = scope.ServiceProvider.GetKeyedService<IDomainEventHandler>(domainEvent.GetType().Name);
				if (handler is not null)
				{
					await handler.Handle(domainEvent, context.CancellationToken);
				}
			}
			catch (Exception caughtException)
			{
				logger.LogError(caughtException,
				                "{Module} - Exception while processing outbox message {MessageId}",
				                ModuleName,
				                outboxMessage.Id);

				exception = caughtException;
			}

			await UpdateOutboxMessageAsync(outboxMessage, exception);
		}

		logger.LogInformation("{Module} - Completed processing outbox messages", ModuleName);
	}

	private async Task<IReadOnlyList<OutboxMessage>> GetOutboxMessagesAsync()
	{
		var outboxMessages = await dbContext.OutboxMessages
		                                              .Where(x => x.ProcessedOnUtc == null)
		                                              .OrderBy(x => x.OccurredOnUtc)
													  .Take(outboxOptions.Value.BatchSize)
		                                              .ToListAsync();

		return outboxMessages;
	}

	private async Task UpdateOutboxMessageAsync(OutboxMessage outboxMessage, Exception? exception)
	{
		var error = exception?.ToString();
		await dbContext.OutboxMessages.Where(x => x.Id == outboxMessage.Id)
		                         .ExecuteUpdateAsync(m => m.SetProperty(p => p.Error, error)
		                                                   .SetProperty(
			                                                   p => p.ProcessedOnUtc,
			                                                   dateTimeProvider.GetUtcNow().UtcDateTime));
	}
}