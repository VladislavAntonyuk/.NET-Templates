using App1.Common.Application.EventBus;

namespace App1.Modules.Module2s.IntegrationEvents;

public sealed class Module2CreatedIntegrationEvent(
	Guid id,
	DateTime occurredOnUtc,
	Guid module2Id) : IntegrationEvent(id, occurredOnUtc)
{
	public Guid Module2Id { get; init; } = module2Id;
}