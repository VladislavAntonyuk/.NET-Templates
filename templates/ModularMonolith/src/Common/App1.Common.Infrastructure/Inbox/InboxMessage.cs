namespace App1.Common.Infrastructure.Inbox;

public sealed class InboxMessage
{
	public Guid Id { get; init; }

	public required string Content { get; init; }

	public DateTime OccurredOnUtc { get; init; }

	public DateTime? ProcessedOnUtc { get; init; }

	public string? Error { get; init; }
}