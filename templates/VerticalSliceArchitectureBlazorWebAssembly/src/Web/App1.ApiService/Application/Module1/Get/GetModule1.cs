using App1.ApiService.Application.Module1.Get;
using App1.ApiService.Infrastructure.Results;

namespace App1.ApiService.Application.Module1.Get;

internal static class GetModule1
{
	public static RouteGroupBuilder MapGetModule1(this RouteGroupBuilder routes)
	{
		routes.MapGet("/{id:guid}", Handler)
		      .WithName("Get Module1 By Id")
		      .WithSummary("Get Module1 By Id")
		      .RequireAuthorization();

		return routes;
	}

	private static async Task<IResult> Handler(
		Guid id,
		GetModule1Handler handler,
		CancellationToken cancellationToken)
	{
		var result = await handler.Handle(id, cancellationToken);
		return result.Match(Results.Ok, Results.NotFound);
	}

	internal record ResponseContent(Guid Id, string? Prop1);
}