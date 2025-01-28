using App1.Common.Infrastructure.Authorization;
using App1.Common.Presentation.Endpoints;
using App1.Modules.Module1s.Infrastructure.Database;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace App1.Modules.Module1s.Application.Get;

internal sealed class GetModule1s : IEndpoint
{
	public void MapEndpoint(IEndpointRouteBuilder app)
	{
		app.MapGet("Module1s", (Module1sDbContext context, CancellationToken cancellationToken) =>
		   {
			   return context.Module1s.AsAsyncEnumerable().WithCancellation(cancellationToken);
		   })
		   .RequireAuthorization(PolicyConstants.AdministratorPolicy)
		   .WithTags(Tags.Module1s);
	}
}