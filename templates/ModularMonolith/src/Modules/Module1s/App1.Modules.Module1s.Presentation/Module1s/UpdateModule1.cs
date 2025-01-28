using System.Security.Claims;
using App1.Common.Infrastructure.Authentication;
using App1.Common.Presentation.Endpoints;
using App1.Common.Presentation.Results;
using App1.Modules.Module1s.Application.Module1s.UpdateModule1;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace App1.Modules.Module1s.Presentation.Module1s;

internal sealed class UpdateModule1 : IEndpoint
{
	public void MapEndpoint(IEndpointRouteBuilder app)
	{
		app.MapPut("Module1s/{id:guid}", async (Guid id, Request request, ISender sender) =>
		   {
			   var result = await sender.Send(new UpdateModule1Command(id));

			   return result.Match(Results.NoContent, ApiResults.Problem);
		   })
		   .RequireAuthorization()
		   .WithTags(Tags.Module1s);
	}

	internal sealed class Request
	{
		public bool Prop1 { get; set; }
	}
}