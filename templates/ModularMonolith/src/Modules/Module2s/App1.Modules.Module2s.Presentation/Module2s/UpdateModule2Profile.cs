using System.Security.Claims;
using App1.Common.Infrastructure.Authentication;
using App1.Common.Presentation.Endpoints;
using App1.Common.Presentation.Results;
using App1.Modules.Module2s.Application.Module2s.UpdateModule2;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace App1.Modules.Module2s.Presentation.Module2s;

internal sealed class UpdateModule2Profile : IEndpoint
{
	public void MapEndpoint(IEndpointRouteBuilder app)
	{
		app.MapPut("Module2s/{id:guid}", async (Guid id, Request request, ISender sender) =>
		   {
			   var result = await sender.Send(new UpdateModule2Command(id));

			   return result.Match(Results.NoContent, ApiResults.Problem);
		   })
		   .RequireAuthorization()
		   .WithTags(Tags.Module2s);
	}

	internal sealed class Request
	{
		public bool Prop1 { get; set; }
	}
}