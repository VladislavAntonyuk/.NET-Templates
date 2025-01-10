using System.Security.Claims;
using App1.Common.Infrastructure.Authentication;
using App1.Common.Infrastructure.Authorization;
using App1.Common.Presentation.Endpoints;
using App1.Common.Presentation.Results;
using App1.Modules.Module2s.Application.Module2s.DeleteModule2;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace App1.Modules.Module2s.Presentation.Module2s;

internal sealed class DeleteModule2 : IEndpoint
{
	public void MapEndpoint(IEndpointRouteBuilder app)
	{
		app.MapDelete("Module2s/{id:guid}", async (Guid id, ISender sender) =>
		   {
			   var result = await sender.Send(new DeleteModule2Command(id));

			   return result.Match(Results.NoContent, ApiResults.Problem);
		   })
		   .RequireAuthorization()
		   .WithTags(Tags.Module2s);
	}
}