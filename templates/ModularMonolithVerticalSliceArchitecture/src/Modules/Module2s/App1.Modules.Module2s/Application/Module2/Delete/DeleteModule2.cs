using App1.Common.Domain;
using App1.Common.Presentation.Endpoints;
using App1.Common.Presentation.Results;
using App1.Modules.Module2s.Application.Module2;
using App1.Modules.Module2s.Infrastructure.Database;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;

namespace App1.Modules.Module2s.Application.Module2.Delete;

internal sealed class DeleteModule2 : IEndpoint
{
	public void MapEndpoint(IEndpointRouteBuilder app)
	{
		app.MapDelete("Module2s/{id:guid}", async (Guid id, Module2sDbContext context, CancellationToken cancellationToken) =>
		   {
			   var module2 = await context.Module2s.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
			   if (module2 is null)
			   {
				   return ApiResults.Problem(Result.Failure(Module2Errors.NotFound(id)));
			   }

			   module2.Delete();
			   context.Module2s.Remove(module2);
			   await context.SaveChangesAsync(cancellationToken);

			   return Results.NoContent();
		   })
		   .RequireAuthorization()
		   .WithTags(Tags.Module2s);
	}
}