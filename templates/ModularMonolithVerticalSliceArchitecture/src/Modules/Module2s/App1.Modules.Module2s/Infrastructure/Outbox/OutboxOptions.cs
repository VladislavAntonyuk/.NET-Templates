namespace App1.Modules.Module2s.Infrastructure.Outbox;

internal sealed class OutboxOptions
{
	public int IntervalInSeconds { get; init; }

	public int BatchSize { get; init; }
}