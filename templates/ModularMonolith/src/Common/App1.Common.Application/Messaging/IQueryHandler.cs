using Mediator;

namespace App1.Common.Application.Messaging;

using Domain;

public interface IQueryHandler<in TQuery, TResponse> : IRequestHandler<TQuery, Result<TResponse>>
	where TQuery : IQuery<TResponse>;