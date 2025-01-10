using App1.Common.Presentation.Endpoints;
using App1.Common.Presentation.Results;
using App1.Modules.Module1s.Application.Module1s.GetModule1ById;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace App1.Modules.Module1s.Presentation.Module1s;

internal sealed class GetModule1ById : IEndpoint
{
	public void MapEndpoint(IEndpointRouteBuilder app)
	{
		app.MapGet("Module1s/{id:guid}", async (Guid id, ISender sender) =>
		   {
			   var result = await sender.Send(new GetModule1Query(id));

			   return result.Match(Results.Ok, ApiResults.Problem);
		   })
		   .RequireAuthorization()
		   .WithTags(Tags.Module1s);
	}
}