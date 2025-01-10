using App1.Common.Domain;

namespace App1.Modules.Module1s.Domain.Module1s;

public sealed class Module1CreatedDomainEvent(Guid module1Id) : DomainEvent
{
	public Guid Module1Id { get; init; } = module1Id;
}