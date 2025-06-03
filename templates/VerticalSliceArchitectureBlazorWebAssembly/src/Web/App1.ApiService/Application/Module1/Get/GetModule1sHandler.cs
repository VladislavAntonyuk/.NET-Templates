using App1.ApiService.Infrastructure.Database;
using App1.ApiService.Infrastructure.Results;
using Microsoft.EntityFrameworkCore;

namespace App1.ApiService.Application.Module1.Get;

internal sealed class GetModule1Handler(Module1sDbContext context)
{
	public async Task<Result<GetModule1.ResponseContent>> Handle(Guid id, CancellationToken cancellationToken = default)
	{
		var model = await context.Module1s.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
		return model is null ? Result.Failure<GetModule1.ResponseContent>(Module1Errors.NotFound(id)) : Result.Success(new GetModule1.ResponseContent(model.Id, model.Prop1));
	}
}