namespace App1.Application.UseCases.Class1.Queries.GetClass1ById;

using Interfaces.CQRS;

public class GetClass1ByIdQuery : IQuery<Class1Dto>
{
	public GetClass1ByIdQuery(int id)
	{
		Id = id;
	}

	public int Id { get; }
}