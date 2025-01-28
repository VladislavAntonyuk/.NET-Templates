using App1.Common.Domain;
using App1.Common.Presentation.Endpoints;
using App1.Common.Presentation.Results;
using App1.Modules.Module2s.Application.Module2;
using App1.Modules.Module2s.Infrastructure.Database;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;

namespace App1.Modules.Module2s.Application.Module2.Get;

internal sealed class GetModule2ById : IEndpoint
{
	public void MapEndpoint(IEndpointRouteBuilder app)
	{
		app.MapGet("Module2s/{id:guid}", async (Guid id, Module2sDbContext context, CancellationToken cancellationToken) =>
		   {
			   var result = await context.Module2s.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
			   return result is null ? ApiResults.Problem(Result.Failure(Module2Errors.NotFound(id))) : Results.Ok(result);
		   })
		   .RequireAuthorization()
		   .WithTags(Tags.Module2s);
	}
}