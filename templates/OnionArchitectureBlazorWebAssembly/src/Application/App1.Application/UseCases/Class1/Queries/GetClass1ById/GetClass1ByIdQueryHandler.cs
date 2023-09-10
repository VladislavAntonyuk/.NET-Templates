namespace App1.Application.UseCases.Class1.Queries.GetClass1ById;

using Interfaces;
using Interfaces.CQRS;

public class GetClass1ByIdQueryHandler : IQueryHandler<Class1Dto, GetClass1ByIdQuery>
{
	private readonly IClass1Repository class1Repository;

	public GetClass1ByIdQueryHandler(IClass1Repository class1Repository)
	{
		this.class1Repository = class1Repository;
	}

	public async ValueTask<IOperationResult<Class1Dto>> Handle(GetClass1ByIdQuery request, CancellationToken cancellationToken)
	{
		var class1 = await class1Repository.GetById(request.Id, cancellationToken);
		if (class1 is not null)
		{
			return new OperationResult<Class1Dto>
			{
				Value = Class1Dto.From(class1)
			};
		}

		var result = new OperationResult<Class1Dto>();
		result.Errors.Add("Class1 not found");
		return result;
	}
}