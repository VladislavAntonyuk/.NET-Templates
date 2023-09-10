namespace App1.Infrastructure.Data.Dispatchers;

using Application.Interfaces.CQRS;
using Mediator;

public class QueryDispatcher : IQueryDispatcher
{
	private readonly ISender sender;

	public QueryDispatcher(ISender sender)
	{
		this.sender = sender;
	}

	public ValueTask<IOperationResult<TResult>> SendAsync<TResult, TQuery>(TQuery query, CancellationToken cancellationToken)
		where TQuery : Application.Interfaces.CQRS.IQuery<TResult>
	{
		return sender.Send(query, cancellationToken);
	}
}