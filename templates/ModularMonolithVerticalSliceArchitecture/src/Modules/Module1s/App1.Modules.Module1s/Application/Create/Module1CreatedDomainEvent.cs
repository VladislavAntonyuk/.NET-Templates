using App1.Common.Domain;

namespace App1.Modules.Module1s.Application.Create;

public sealed class Module1CreatedDomainEvent(Guid module1Id) : DomainEvent
{
	public Guid Module1Id { get; init; } = module1Id;
}