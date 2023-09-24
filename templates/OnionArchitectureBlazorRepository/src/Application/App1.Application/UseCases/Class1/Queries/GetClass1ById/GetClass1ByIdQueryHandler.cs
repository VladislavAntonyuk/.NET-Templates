namespace App1.Application.UseCases.Class1.Queries.GetClass1ById;

using Interfaces.CQRS;
using Interfaces.Repositories;

public class GetClass1ByIdQueryHandler : BaseClass1Handler, IQueryHandler<Class1Dto, GetClass1ByIdQuery>
{
	public GetClass1ByIdQueryHandler(IClass1Repository class1Repository) : base(class1Repository)
	{
	}

	public async ValueTask<IOperationResult<Class1Dto>> Handle(GetClass1ByIdQuery request, CancellationToken cancellationToken)
	{
		var class1 = await Class1Repository.GetById(request.Id, cancellationToken);
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