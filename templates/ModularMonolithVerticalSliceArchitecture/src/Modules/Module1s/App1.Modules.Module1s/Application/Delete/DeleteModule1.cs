using App1.Common.Domain;
using App1.Common.Presentation.Endpoints;
using App1.Common.Presentation.Results;
using App1.Modules.Module1s.Infrastructure.Database;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;

namespace App1.Modules.Module1s.Application.Delete;

internal sealed class DeleteModule1 : IEndpoint
{
	public void MapEndpoint(IEndpointRouteBuilder app)
	{
		app.MapDelete("Module1s/{id:guid}", async (Guid id, Module1sDbContext context, CancellationToken cancellationToken) =>
		   {
			   var module1 = await context.Module1s.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
			   if (module1 is null)
			   {
				   return ApiResults.Problem(Result.Failure(Module1Errors.NotFound(id)));
			   }

			   module1.Delete();
			   context.Module1s.Remove(module1);
			   await context.SaveChangesAsync(cancellationToken);

			   return Results.NoContent();
		   })
		   .RequireAuthorization()
		   .WithTags(Tags.Module1s);
	}
}