using App1.Common.Domain;
using App1.Common.Presentation.Endpoints;
using App1.Common.Presentation.Results;
using App1.Modules.Module2s.Infrastructure.Database;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace App1.Modules.Module2s.Application.Module2.Create;

internal sealed class CreateModule2 : IEndpoint
{
	public void MapEndpoint(IEndpointRouteBuilder app)
	{
		app.MapPost("module2s", async (Request? request, Module2sDbContext context, CancellationToken cancellationToken) =>
		   {
			   if (request is null)
			   {
				   return ApiResults.Problem(Result.Failure(Error.NullValue));
			   }

			   var module2 = Module2.Create(Guid.CreateVersion7());
			   context.Add(module2);
			   await context.SaveChangesAsync(cancellationToken);
			   return Results.Ok(new ResponseContent(module2.Id));
		   })
		   .WithTags(Tags.Module2s);
	}

	internal sealed class Request
	{
		public required string Prop1 { get; init; }
	}

	internal record ResponseContent(Guid Id);
}