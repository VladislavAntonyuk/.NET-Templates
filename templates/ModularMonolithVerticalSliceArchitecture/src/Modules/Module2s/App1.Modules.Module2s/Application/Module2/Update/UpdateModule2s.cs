using App1.Common.Domain;
using App1.Common.Presentation.Endpoints;
using App1.Common.Presentation.Results;
using App1.Modules.Module2s.Infrastructure.Database;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;

namespace App1.Modules.Module2s.Application.Module2.Update;

internal sealed class UpdateModule2s : IEndpoint
{
	public void MapEndpoint(IEndpointRouteBuilder app)
	{
		app.MapPut("Module2s/{id:guid}", async (Guid id, Request? request, Module2sDbContext context, CancellationToken cancellationToken) =>
		   {
			   if (request is null)
			   {
				   return ApiResults.Problem(Result.Failure(Error.NullValue));
			   }

			   var module2 = await context.Module2s.AsTracking().FirstOrDefaultAsync(x=>x.Id == id, cancellationToken);
			   if (module2 is null)
			   {
				   return ApiResults.Problem(Result.Failure(Module2Errors.NotFound(id)));
			   }

			   module2.Update();
			   await context.SaveChangesAsync(cancellationToken);
			   return Results.Ok(new ResponseContent(module2.Id));
		   })
		   .RequireAuthorization()
		   .WithTags(Tags.Module2s);
	}

	internal sealed class Request
	{
		public bool Prop1 { get; set; }
	}

	internal record ResponseContent(Guid Id);
}