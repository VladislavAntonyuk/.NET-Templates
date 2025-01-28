using App1.Common.Domain;
using App1.Common.Presentation.Endpoints;
using App1.Common.Presentation.Results;
using App1.Modules.Module1s.Infrastructure.Database;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace App1.Modules.Module1s.Application.Create;

internal sealed class CreateModule1 : IEndpoint
{
	public void MapEndpoint(IEndpointRouteBuilder app)
	{
		app.MapPost("module1s", async (Request? request, Module1sDbContext context, CancellationToken cancellationToken) =>
		   {
			   if (request is null)
			   {
				   return ApiResults.Problem(Result.Failure(Error.NullValue));
			   }

			   var module1 = Module1.Create(Guid.CreateVersion7());
			   context.Add(module1);
			   await context.SaveChangesAsync(cancellationToken);
			   return Results.Ok(new ResponseContent(module1.Id));
		   })
		   .WithTags(Tags.Module1s);
	}

	internal sealed class Request
	{
		public required string Prop1 { get; init; }
	}

	internal record ResponseContent(Guid Id);
}