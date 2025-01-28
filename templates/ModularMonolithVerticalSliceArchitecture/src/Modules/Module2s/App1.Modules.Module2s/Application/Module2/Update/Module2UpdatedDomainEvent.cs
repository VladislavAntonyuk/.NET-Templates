using App1.Common.Domain;

namespace App1.Modules.Module2s.Application.Module2.Update;

public sealed class Module2UpdatedDomainEvent(Guid module2Id) : DomainEvent
{
	public Guid Module2Id { get; init; } = module2Id;
}