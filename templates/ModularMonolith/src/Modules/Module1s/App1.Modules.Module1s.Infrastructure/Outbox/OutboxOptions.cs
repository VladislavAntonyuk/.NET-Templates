namespace App1.Modules.Module1s.Infrastructure.Outbox;

internal sealed class OutboxOptions
{
	public int IntervalInSeconds { get; init; }

	public int BatchSize { get; init; }
}