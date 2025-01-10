using App1.Common.Presentation.Endpoints;
using App1.Modules.Module1s.Application.Module1s.CreateModule1;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace App1.Modules.Module1s.Presentation.Module1s;

internal sealed class CreateModule1 : IEndpoint
{
	public void MapEndpoint(IEndpointRouteBuilder app)
	{
		app.MapPost("module1s", async (Request? request, ISender sender) =>
		   {
			   if (request is null)
			   {
				   return Results.BadRequest(
					   new ResponseContent( "There was a problem with your request."));
			   }

			   var result = await sender.Send(new CreateModule1Command(request.ObjectId));
			   if (result.IsSuccess)
			   {
				   return Results.Ok(new ResponseContent());
			   }

			   return Results.BadRequest(new ResponseContent(result.Error.Description));
		   })
		   .WithTags(Tags.Module1s);
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