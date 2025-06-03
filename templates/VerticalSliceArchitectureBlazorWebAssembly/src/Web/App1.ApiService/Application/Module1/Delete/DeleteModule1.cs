using App1.ApiService.Application.Module1.Create;
using App1.ApiService.Infrastructure.Results;

namespace App1.ApiService.Application.Module1.Delete;

internal static class DeleteModule1
{
	public static RouteGroupBuilder MapDeleteModule1s(this RouteGroupBuilder routes)
	{
		routes.MapDelete("/{id:guid}", Handler)
		      .WithName("Delete Module1s")
		      .WithSummary("Delete Module1s")
		      .RequireAuthorization();

		return routes;
	}

	private static async Task<IResult> Handler(
		Guid id,
		DeleteModule1sHandler handler,
		CancellationToken cancellationToken)
	{
		var result = await handler.Handle(id, cancellationToken);
		return result.Match(Results.NoContent, ApiResults.Problem);
	}
}