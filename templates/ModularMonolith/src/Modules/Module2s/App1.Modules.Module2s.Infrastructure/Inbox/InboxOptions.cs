namespace App1.Modules.Module2s.Infrastructure.Inbox;

internal sealed class InboxOptions
{
	public int IntervalInSeconds { get; init; }

	public int BatchSize { get; init; }
}