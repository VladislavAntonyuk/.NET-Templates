namespace App1.Application.Interfaces.CQRS;

using Mediator;

public interface IQueryDispatcher
{
	ValueTask<TResult> SendAsync<TResult>(
		IQuery<TResult> query,
		CancellationToken cancellationToken = default);
}