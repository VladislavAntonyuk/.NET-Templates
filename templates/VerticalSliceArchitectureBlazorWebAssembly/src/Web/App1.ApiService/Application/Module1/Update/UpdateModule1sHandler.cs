using App1.ApiService.Infrastructure.Database;
using App1.ApiService.Infrastructure.Results;
using Microsoft.EntityFrameworkCore;

namespace App1.ApiService.Application.Module1.Update;

internal sealed class UpdateModule1sHandler(Module1sDbContext context)
{
	public async Task<Result<UpdateModule1.ResponseContent>> Handle(UpdateModule1.Request request, CancellationToken cancellationToken = default)
	{
		var module1 = await context.Module1s.AsTracking().FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
		if (module1 is null)
		{
			return Result.Failure<UpdateModule1.ResponseContent>(Module1Errors.NotFound(request.Id));
		}

		module1.Prop1 = request.Prop1;
		await context.SaveChangesAsync(cancellationToken);
		return Result.Success(new UpdateModule1.ResponseContent(module1.Id, module1.Prop1));
	}
}