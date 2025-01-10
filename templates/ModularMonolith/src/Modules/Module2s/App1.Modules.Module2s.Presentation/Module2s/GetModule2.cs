using App1.Common.Infrastructure.Authorization;
using App1.Common.Presentation.Endpoints;
using App1.Common.Presentation.Results;
using App1.Modules.Module2s.Application.Module2s.GetModule2s;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace App1.Modules.Module2s.Presentation.Module2s;

internal sealed class GetModule2S : IEndpoint
{
	public void MapEndpoint(IEndpointRouteBuilder app)
	{
		app.MapGet("Module2s", async (ISender sender) =>
		   {
			   var result = await sender.Send(new GetModule2SQuery());

			   return result.Match(Results.Ok, ApiResults.Problem);
		   })
		   .RequireAuthorization(PolicyConstants.AdministratorPolicy)
		   .WithTags(Tags.Module2s);
	}
}