namespace App1.Application.UseCases.Class1.Queries.GetClass1ById;

using Infrastructure.Data.Repositories.Models;
using Interfaces.CQRS;
using Microsoft.EntityFrameworkCore;

public class GetClass1ByIdQueryHandler : IQueryHandler<Class1Dto, GetClass1ByIdQuery>
{
	private readonly IDbContextFactory<ApplicationContext> dbContextFactory;

	public GetClass1ByIdQueryHandler(IDbContextFactory<ApplicationContext> dbContextFactory)
	{
		this.dbContextFactory = dbContextFactory;
	}

	public async ValueTask<IOperationResult<Class1Dto>> Handle(GetClass1ByIdQuery request, CancellationToken cancellationToken)
	{
		await using var dbContext = await dbContextFactory.CreateDbContextAsync(cancellationToken);
		var class1 = await dbContext.Class1.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
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