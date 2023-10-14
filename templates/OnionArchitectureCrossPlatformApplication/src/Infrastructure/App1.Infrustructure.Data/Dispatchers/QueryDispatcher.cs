namespace App1.Infrastructure.Data.Dispatchers;

using Application.Interfaces.CQRS;
using Mediator;

public class QueryDispatcher(ISender sender) : IQueryDispatcher
{
	public ValueTask<TResult> SendAsync<TResult>(IQuery<TResult> query, CancellationToken cancellationToken = default)
	{
		return sender.Send(query, cancellationToken);
	}
}