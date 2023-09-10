namespace App1.Application.UseCases.Class1.Queries.GetClass1;

using Interfaces;
using Interfaces.CQRS;

public class GetClass1QueryHandler : IQueryHandler<GetClass1ByFilterResponse, GetClass1Query>
{
	private readonly IClass1Repository class1Repository;

	public GetClass1QueryHandler(IClass1Repository class1Repository)
	{
		this.class1Repository = class1Repository;
	}

	public async ValueTask<IOperationResult<GetClass1ByFilterResponse>> Handle(GetClass1Query request, CancellationToken cancellationToken)
	{
		var items = await class1Repository.GetAll(cancellationToken);
		var result = items.Where(x => x.Name.Contains(request.Name ?? string.Empty))
						  .Skip(request.Offset)
						  .Take(request.Limit)
						  .Select(Class1Dto.From)
						  .ToList();
		return new OperationResult<GetClass1ByFilterResponse>
		{
			Value = new GetClass1ByFilterResponse()
			{
				Items = result,
				TotalCount = result.Count,
				PageIndex = request.Offset / request.Limit,
				TotalPages = (int)Math.Round((double)result.Count / request.Limit, MidpointRounding.ToPositiveInfinity),
			}
		};
	}
}