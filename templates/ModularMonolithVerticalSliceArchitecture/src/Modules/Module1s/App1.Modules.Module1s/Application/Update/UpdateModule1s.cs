using App1.Common.Domain;
using App1.Common.Presentation.Endpoints;
using App1.Common.Presentation.Results;
using App1.Modules.Module1s.Infrastructure.Database;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;

namespace App1.Modules.Module1s.Application.Update;

internal sealed class UpdateModule1s : IEndpoint
{
	public void MapEndpoint(IEndpointRouteBuilder app)
	{
		app.MapPut("Module1s/{id:guid}", async (Guid id, Request? request, Module1sDbContext context, CancellationToken cancellationToken) =>
		   {
			   if (request is null)
			   {
				   return ApiResults.Problem(Result.Failure(Error.NullValue));
			   }

			   var module1 = await context.Module1s.AsTracking().FirstOrDefaultAsync(x=>x.Id == id, cancellationToken);
			   if (module1 is null)
			   {
				   return ApiResults.Problem(Result.Failure(Module1Errors.NotFound(id)));
			   }

			   module1.Update();
			   await context.SaveChangesAsync(cancellationToken);
			   return Results.Ok(new ResponseContent(module1.Id));
		   })
		   .RequireAuthorization()
		   .WithTags(Tags.Module1s);
	}

	internal sealed class Request
	{
		public bool Prop1 { get; set; }
	}

	internal record ResponseContent(Guid Id);
}