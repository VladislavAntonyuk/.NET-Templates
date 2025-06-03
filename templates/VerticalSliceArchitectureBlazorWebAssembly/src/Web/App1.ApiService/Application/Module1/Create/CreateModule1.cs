using App1.ApiService.Infrastructure.Results;

namespace App1.ApiService.Application.Module1.Create;

internal static class CreateModule1
{
	public static RouteGroupBuilder MapCreateModule1s(this RouteGroupBuilder routes)
	{
		routes.MapPost("/", Handler)
		      .WithName("Create Module1s")
		      .WithSummary("Create Module1s");

		return routes;
	}

	private static async Task<IResult> Handler(
		Request? request,
		CreateModule1sHandler handler,
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
		public required string Prop1 { get; init; }
	}

	internal record ResponseContent(Guid Id, string Prop1);
}