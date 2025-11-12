namespace App1.Common.Application;

using System.Reflection;
using Behaviors;
using FluentValidation;
using Mediator;
using Microsoft.Extensions.DependencyInjection;

public static class ApplicationConfiguration
{
	public static IServiceCollection AddApplication(this IServiceCollection services, Assembly[] moduleAssemblies)
	{
		services.AddMediator(options => options.ServiceLifetime = ServiceLifetime.Scoped);
		services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ExceptionHandlingPipelineBehavior<,>));
		services.AddScoped(typeof(IPipelineBehavior<,>), typeof(RequestLoggingPipelineBehavior<,>));
		services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationPipelineBehavior<,>));

		services.AddValidatorsFromAssemblies(moduleAssemblies, includeInternalTypes: true);

		return services;
	}
}