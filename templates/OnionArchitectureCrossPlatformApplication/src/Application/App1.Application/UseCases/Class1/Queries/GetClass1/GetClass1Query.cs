namespace App1.Application.UseCases.Class1.Queries.GetClass1;

using Interfaces.CQRS;
using Mediator;

public class GetClass1Query : IQuery<OperationResult<GetClass1ByFilterResponse>>
{
	public string? Name { get; set; }
	public int Limit { get; set; }
	public int Offset { get; set; }
}