namespace App1.Application.Interfaces.CQRS;

using MediatR;

public interface IQueryHandler<TResult, in TQuery> : IRequestHandler<TQuery, IOperationResult<TResult>>
	where TQuery : IQuery<TResult>
{
}