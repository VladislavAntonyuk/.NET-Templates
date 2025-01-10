using App1.Common.Domain;

namespace App1.Modules.Module2s.Domain.Module2s;

public sealed class Module2DeletedDomainEvent(Guid module2Id) : DomainEvent
{
	public Guid Module2Id { get; init; } = module2Id;
}