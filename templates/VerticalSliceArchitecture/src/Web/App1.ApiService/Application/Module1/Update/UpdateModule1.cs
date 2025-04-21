using App1.ApiService.Application.Module1.Create;
using App1.ApiService.Infrastructure.Results;

namespace App1.ApiService.Application.Module1.Update;

internal static class UpdateModule1
{
	public static RouteGroupBuilder MapUpdateModule1s(this RouteGroupBuilder routes)
	{
		routes.MapPost("/module1s/{id:guid}", Handler)
		      .WithName("Update Module1s")
		      .WithSummary("Update Module1s");

		return routes;
	}

	private static async Task<IResult> Handler(
		Request? request,
		UpdateModule1sHandler handler,
		CancellationToken cancellationToken)
	{
		if (request is null)
		{
			return ApiResults.Problem(Result.Failure(Error.NullValue));
		}

		var result = await handler.Handle(request, cancellationToken);
		return result.Match(Results.Ok, ApiResults.Problem);
	}

	internal sealed class Request
	{
		public required Guid Id { get; init; }

		public required string Prop1 { get; init; }
	}

	internal record ResponseContent(Guid Id, string Prop1);
}