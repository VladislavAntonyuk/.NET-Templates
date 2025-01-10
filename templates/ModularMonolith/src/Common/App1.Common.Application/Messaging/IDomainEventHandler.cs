namespace App1.Common.Application.Messaging;

using Domain;

public interface IDomainEventHandler<in TDomainEvent> : IDomainEventHandler where TDomainEvent : IDomainEvent
{
	Task Handle(TDomainEvent domainEvent, CancellationToken cancellationToken = default);
}

public interface IDomainEventHandler
{
	Task Handle(IDomainEvent domainEvent, CancellationToken cancellationToken = default);
}