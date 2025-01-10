using System.Security.Claims;
using App1.Common.Infrastructure.Authentication;
using App1.Common.Infrastructure.Authorization;
using App1.Common.Presentation.Endpoints;
using App1.Common.Presentation.Results;
using App1.Modules.Module1s.Application.Module1s.DeleteModule1;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace App1.Modules.Module1s.Presentation.Module1s;

internal sealed class DeleteModule1 : IEndpoint
{
	public void MapEndpoint(IEndpointRouteBuilder app)
	{
		app.MapDelete("Module1s/{id:guid}", async (Guid id, ISender sender) =>
		   {
			   var result = await sender.Send(new DeleteModule1Command(id));

			   return result.Match(Results.NoContent, ApiResults.Problem);
		   })
		   .RequireAuthorization(PolicyConstants.AdministratorPolicy)
		   .WithTags(Tags.Module1s);
	}
}