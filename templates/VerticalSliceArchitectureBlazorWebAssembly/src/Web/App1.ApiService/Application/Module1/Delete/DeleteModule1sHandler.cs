using App1.ApiService.Infrastructure.Database;
using App1.ApiService.Infrastructure.Results;
using Microsoft.EntityFrameworkCore;

namespace App1.ApiService.Application.Module1.Delete;

internal sealed class DeleteModule1sHandler(Module1sDbContext context)
{
	public async Task<Result> Handle(Guid id, CancellationToken cancellationToken = default)
	{
		var module1 = await context.Module1s.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
		if (module1 is null)
		{
			return Result.Failure(Module1Errors.NotFound(id));
		}

		context.Module1s.Remove(module1);
		await context.SaveChangesAsync(cancellationToken);
		return Result.Success();
	}
}