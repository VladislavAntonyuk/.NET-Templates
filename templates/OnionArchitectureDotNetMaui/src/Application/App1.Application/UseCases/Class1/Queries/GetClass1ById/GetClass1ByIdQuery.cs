namespace App1.Application.UseCases.Class1.Queries.GetClass1ById;

using Interfaces.CQRS;
using Mediator;
using Models;

public class GetClass1ByIdQuery(int id) : IQuery<OperationResult<Class1Dto>>
{
	public int Id { get; } = id;
}