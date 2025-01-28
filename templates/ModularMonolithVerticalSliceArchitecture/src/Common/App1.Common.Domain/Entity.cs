namespace App1.Common.Domain;

public abstract class Entity
{
	private readonly List<IDomainEvent> domainEvents = [];

	public IReadOnlyCollection<IDomainEvent> DomainEvents => domainEvents.ToList().AsReadOnly();

	public void ClearDomainEvents()
	{
		domainEvents.Clear();
	}

	protected void Raise(IDomainEvent domainEvent)
	{
		domainEvents.Add(domainEvent);
	}
}