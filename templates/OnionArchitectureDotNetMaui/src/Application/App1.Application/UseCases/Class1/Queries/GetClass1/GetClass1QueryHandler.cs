namespace App1.Application.UseCases.Class1.Queries.GetClass1;

using Infrastructure.Data.Repositories.Models;
using Interfaces.CQRS;
using Microsoft.EntityFrameworkCore;

public class GetClass1QueryHandler : IQueryHandler<GetClass1ByFilterResponse, GetClass1Query>
{
	private readonly IDbContextFactory<ApplicationContext> dbContextFactory;

	public GetClass1QueryHandler(IDbContextFactory<ApplicationContext> dbContextFactory)
	{
		this.dbContextFactory = dbContextFactory;
	}

	public async ValueTask<IOperationResult<GetClass1ByFilterResponse>> Handle(GetClass1Query request, CancellationToken cancellationToken)
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