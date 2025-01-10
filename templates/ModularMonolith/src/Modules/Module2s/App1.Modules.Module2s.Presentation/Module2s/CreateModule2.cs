using App1.Common.Presentation.Endpoints;
using App1.Modules.Module2s.Application.Module2s.CreateModule2;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace App1.Modules.Module2s.Presentation.Module2s;

internal sealed class CreateModule2 : IEndpoint
{
	public void MapEndpoint(IEndpointRouteBuilder app)
	{
		app.MapPost("module2s", async (Request? request, ISender sender) =>
		   {
			   if (request is null)
			   {
				   return Results.BadRequest(
					   new ResponseContent( "There was a problem with your request."));
			   }

			   var result = await sender.Send(new CreateModule2Command(request.ObjectId));
			   if (result.IsSuccess)
			   {
				   return Results.Ok(new ResponseContent());
			   }

			   return Results.BadRequest(new ResponseContent(result.Error.Description));
		   })
		   .WithTags(Tags.Module2s);
	}

	internal sealed class Request
	{
		public required Guid ObjectId { get; init; }
	}

	internal class ResponseContent(string? userMessage = null)
	{
		public string? UserMessage { get; set; } = userMessage;
	}
}