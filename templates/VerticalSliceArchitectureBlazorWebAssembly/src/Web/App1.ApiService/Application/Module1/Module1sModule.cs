using App1.ApiService.Application.Module1.Create;
using App1.ApiService.Application.Module1.Delete;
using App1.ApiService.Application.Module1.Get;
using App1.ApiService.Application.Module1.Update;

namespace App1.ApiService.Application.Module1;

internal static class Module1sModule
{
	public static IEndpointRouteBuilder MapModule1Routes(this IEndpointRouteBuilder routes)
	{
		var group = routes.MapGroup("/module1s")
		                  .WithTags("Module1s")
		                  .WithOpenApi();

		group.MapGetModule1();
		group.MapCreateModule1s();
		group.MapUpdateModule1s();
		group.MapDeleteModule1s();

		return group;
	}
}