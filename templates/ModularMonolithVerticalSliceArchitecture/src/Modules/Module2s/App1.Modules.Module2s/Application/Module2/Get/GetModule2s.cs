using App1.Common.Infrastructure.Authorization;
using App1.Common.Presentation.Endpoints;
using App1.Modules.Module2s.Infrastructure.Database;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace App1.Modules.Module2s.Application.Module2.Get;

internal sealed class GetModule2s : IEndpoint
{
	public void MapEndpoint(IEndpointRouteBuilder app)
	{
		app.MapGet("Module2s", (Module2sDbContext context, CancellationToken cancellationToken) =>
		   {
			   return context.Module2s.AsAsyncEnumerable().WithCancellation(cancellationToken);
		   })
		   .RequireAuthorization(PolicyConstants.AdministratorPolicy)
		   .WithTags(Tags.Module2s);
	}
}