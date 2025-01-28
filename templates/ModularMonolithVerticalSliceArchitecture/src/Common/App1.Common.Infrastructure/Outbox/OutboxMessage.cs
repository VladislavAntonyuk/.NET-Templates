namespace App1.Common.Infrastructure.Outbox;

public sealed class OutboxMessage
{
	public Guid Id { get; init; }

	public required string Content { get; init; }

	public DateTime OccurredOnUtc { get; init; }

	public DateTime? ProcessedOnUtc { get; init; }

	public string? Error { get; init; }
}