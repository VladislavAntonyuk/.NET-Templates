namespace App1.Application.Interfaces.CQRS;

public interface IQueryDispatcher
{
	ValueTask<IOperationResult<TResult>> SendAsync<TResult, TQuery>(TQuery query, CancellationToken cancellationToken)
		where TQuery : IQuery<TResult>;
}