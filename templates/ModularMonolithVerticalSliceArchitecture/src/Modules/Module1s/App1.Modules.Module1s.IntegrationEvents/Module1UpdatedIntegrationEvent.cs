using App1.Common.Application.EventBus;

namespace App1.Modules.Module1s.IntegrationEvents;

public sealed class Module1UpdatedIntegrationEvent(
	Guid id,
	DateTime occurredOnUtc,
	Guid module1Id) : IntegrationEvent(id, occurredOnUtc)
{
	public Guid Module1Id { get; init; } = module1Id;
}