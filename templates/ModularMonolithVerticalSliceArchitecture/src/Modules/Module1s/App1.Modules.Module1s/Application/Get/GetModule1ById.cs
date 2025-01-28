using App1.Common.Domain;
using App1.Common.Presentation.Endpoints;
using App1.Common.Presentation.Results;
using App1.Modules.Module1s.Infrastructure.Database;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;

namespace App1.Modules.Module1s.Application.Get;

public sealed class GetModule1ById : IEndpoint
{
	public void MapEndpoint(IEndpointRouteBuilder app)
	{
		app.MapGet("Module1s/{id:guid}", async (Guid id, Module1sDbContext context, CancellationToken cancellationToken) =>
		   {
			   var result = await context.Module1s.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
			   return result is null ? ApiResults.Problem(Result.Failure(Module1Errors.NotFound(id))) : Results.Ok(new Module1Response(result.Id));
		   })
		   .RequireAuthorization()
		   .WithTags(Tags.Module1s);
	}

	public record Module1Response(Guid Id);
}