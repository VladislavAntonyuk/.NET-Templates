namespace App1.Common.Application.Messaging;

using Domain;
using MediatR;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>;