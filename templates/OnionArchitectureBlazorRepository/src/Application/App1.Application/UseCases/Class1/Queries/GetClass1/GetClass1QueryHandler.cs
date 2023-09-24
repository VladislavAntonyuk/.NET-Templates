namespace App1.Application.UseCases.Class1.Queries.GetClass1;

using Interfaces.CQRS;
using Interfaces.Repositories;

public class GetClass1QueryHandler : BaseClass1Handler, IQueryHandler<GetClass1ByFilterResponse, GetClass1Query>
{
	public GetClass1QueryHandler(IClass1Repository class1Repository) : base(class1Repository)
	{
	}

	public async ValueTask<IOperationResult<GetClass1ByFilterResponse>> Handle(GetClass1Query request, CancellationToken cancellationToken)
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