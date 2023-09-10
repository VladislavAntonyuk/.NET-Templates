namespace App1.Application.Interfaces.CQRS;

using Mediator;

public interface IQueryHandler<TResult, in TQuery> : IRequestHandler<TQuery, IOperationResult<TResult>>
	where TQuery : IQuery<TResult>
{
}