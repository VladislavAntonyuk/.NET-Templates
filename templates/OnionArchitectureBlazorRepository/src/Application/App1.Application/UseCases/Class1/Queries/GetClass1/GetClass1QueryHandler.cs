namespace App1.Application.UseCases.Class1.Queries.GetClass1;

using Interfaces.CQRS;
using Interfaces.Repositories;
using Mediator;

public class GetClass1QueryHandler(IClass1Repository class1Repository) : BaseClass1Handler(class1Repository),
                                                                         IQueryHandler<GetClass1Query, OperationResult<GetClass1ByFilterResponse>>
{
	public async ValueTask<OperationResult<GetClass1ByFilterResponse>> Handle(GetClass1Query request, CancellationToken cancellationToken)
	{
		var result = await Class1Repository.GetAll(cancellationToken);
		return new OperationResult<GetClass1ByFilterResponse>
		{
			Value = new GetClass1ByFilterResponse
			{
				Items = result.Select(Class1Dto.From).ToList(),
				TotalCount = result.Count
			}
		};
	}
}