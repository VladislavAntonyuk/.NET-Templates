using System.Text.Json;
using App1.Common.Application.EventBus;
using App1.Common.Infrastructure.Inbox;
using App1.Common.Infrastructure.Serialization;
using App1.Modules.Module2s.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Quartz;

namespace App1.Modules.Module2s.Infrastructure.Inbox;

[DisallowConcurrentExecution]
internal sealed class ProcessInboxJob(
	Module2sDbContext dbContext,
	IServiceScopeFactory serviceScopeFactory,
	TimeProvider timeProvider,
	IOptions<InboxOptions> inboxOptions,
	ILogger<ProcessInboxJob> logger) : IJob
{
	private const string ModuleName = "Travellers";

	public async Task Execute(IJobExecutionContext context)
	{
		logger.LogInformation("{Module} - Beginning to process inbox messages", ModuleName);

		var inboxMessages = await GetInboxMessagesAsync();
		foreach (var inboxMessage in inboxMessages)
		{
			Exception? exception = null;

			try
			{
				var integrationEvent = JsonSerializer.Deserialize<IIntegrationEvent>(inboxMessage.Content, SerializerSettings.Instance)!;

				using var scope = serviceScopeFactory.CreateScope();
				var handler = scope.ServiceProvider.GetRequiredKeyedService<IIntegrationEventHandler>(integrationEvent.GetType().Name);
				await handler.Handle(integrationEvent, context.CancellationToken);
			}
			catch (Exception caughtException)
			{
				logger.LogError(caughtException,
				                "{Module} - Exception while processing inbox message {MessageId}",
				                ModuleName,
				                inboxMessage.Id);

				exception = caughtException;
			}

			await UpdateInboxMessageAsync(inboxMessage, exception);
		}

		logger.LogInformation("{Module} - Completed processing inbox messages", ModuleName);
	}

	private async Task<IReadOnlyList<InboxMessage>> GetInboxMessagesAsync()
	{
		var inboxMessages = await dbContext.InboxMessages
		                                             .Where(x => x.ProcessedOnUtc == null)
		                                             .OrderBy(x => x.OccurredOnUtc)
		                                             .Take(inboxOptions.Value.BatchSize)
		                                             .ToListAsync();

		return inboxMessages;
	}

	private async Task UpdateInboxMessageAsync(InboxMessage inboxMessage, Exception? exception)
	{
		var message = exception?.Message ?? null;
		await dbContext.InboxMessages.Where(x => x.Id == inboxMessage.Id)
		                         .ExecuteUpdateAsync(
			                         m => m.SetProperty(p => p.ProcessedOnUtc, timeProvider.GetUtcNow().UtcDateTime)
			                               .SetProperty(p => p.Error, message));
	}
}