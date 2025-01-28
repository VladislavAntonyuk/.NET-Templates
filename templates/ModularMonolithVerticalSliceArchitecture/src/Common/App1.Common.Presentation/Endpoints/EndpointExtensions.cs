namespace App1.Common.Presentation.Endpoints;

using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

public static class EndpointExtensions
{
	public static IServiceCollection AddEndpoints(this IServiceCollection services, params Assembly[] assemblies)
	{
		var serviceDescriptors = assemblies.SelectMany(a => a.GetTypes())
		                                   .Where(type => type is { IsAbstract: false, IsInterface: false } &&
		                                                  type.IsAssignableTo(typeof(IEndpoint)))
		                                   .Select(type => ServiceDescriptor.Transient(typeof(IEndpoint), type))
		                                   .ToArray();

		services.TryAddEnumerable(serviceDescriptors);

		return services;
	}

	public static IApplicationBuilder MapEndpoints(this WebApplication app, RouteGroupBuilder? routeGroupBuilder = null)
	{
		var endpoints = app.Services.GetRequiredService<IEnumerable<IEndpoint>>();

		IEndpointRouteBuilder builder = routeGroupBuilder is null ? app : routeGroupBuilder;

		foreach (var endpoint in endpoints)
		{
			endpoint.MapEndpoint(builder);
		}

		return app;
	}
}