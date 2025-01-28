using App1.Common.Domain;

namespace App1.Modules.Module1s.Application.Delete;

public sealed class Module1DeletedDomainEvent(Guid module1Id) : DomainEvent
{
	public Guid Module1Id { get; init; } = module1Id;
}