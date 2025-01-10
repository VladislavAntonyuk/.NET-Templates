namespace App1.Common.Application.EventBus;

public interface IIntegrationEventHandler<in TIntegrationEvent> : IIntegrationEventHandler
	where TIntegrationEvent : IIntegrationEvent
{
	Task Handle(TIntegrationEvent integrationEvent, CancellationToken cancellationToken = default);
}

public interface IIntegrationEventHandler
{
	Task Handle(IIntegrationEvent integrationEvent, CancellationToken cancellationToken = default);
}