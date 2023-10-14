namespace App1.Application.UseCases.Class1.Queries.GetClass1;

using Configuration.Database;
using Interfaces.CQRS;
using Mediator;
using Microsoft.EntityFrameworkCore;
using Models;

public class GetClass1QueryHandler(IDbContextFactory<ApplicationContext> dbContextFactory) : IQueryHandler<GetClass1Query, OperationResult<GetClass1ByFilterResponse>>
{
	public async ValueTask<OperationResult<GetClass1ByFilterResponse>> Handle(GetClass1Query request, CancellationToken cancellationToken)
	{
		await using var dbContext = await dbContextFactory.CreateDbContextAsync(cancellationToken);
		var query = dbContext.Class1.Skip(request.Offset);
		if (!string.IsNullOrEmpty(request.Name))
		{
			query = query.Where(x => x.Name.Contains(request.Name));
		}

		if (request.Limit > 0)
		{
			query = query.Take(request.Limit);
		}

		var result = await query.Select(x => Class1Dto.From(x)).ToListAsync(cancellationToken);
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