namespace App1.Application.UseCases.Class1.Queries.GetClass1;

using Interfaces;
using Interfaces.CQRS;
using Mediator;
using Models;

public class GetClass1QueryHandler(IClass1Repository class1Repository) : IQueryHandler<GetClass1Query, OperationResult<GetClass1ByFilterResponse>>
{
	public async ValueTask<OperationResult<GetClass1ByFilterResponse>> Handle(GetClass1Query request, CancellationToken cancellationToken)
	{
		var items = await class1Repository.GetAll(cancellationToken);
		var result = items.Where(x => x.Name.Contains(request.Name ?? string.Empty))
						  .Skip(request.Offset)
						  .Take(request.Limit)
						  .Select(Class1Dto.From)
						  .ToList();
		return new OperationResult<GetClass1ByFilterResponse>
		{
			Value = new GetClass1ByFilterResponse
			{
				Items = result,
				TotalCount = result.Count,
				PageIndex = request.Offset / request.Limit,
				TotalPages = (int)Math.Round((double)result.Count / request.Limit, MidpointRounding.ToPositiveInfinity),
			}
		};
	}
}