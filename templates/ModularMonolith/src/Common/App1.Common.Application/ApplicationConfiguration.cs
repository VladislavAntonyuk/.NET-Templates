namespace App1.Common.Application;

using System.Reflection;
using Behaviors;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

public static class ApplicationConfiguration
{
	public static IServiceCollection AddApplication(this IServiceCollection services, Assembly[] moduleAssemblies)
	{
		services.AddMediatR(config =>
		{
			config.RegisterServicesFromAssemblies(moduleAssemblies);

			config.AddOpenBehavior(typeof(ExceptionHandlingPipelineBehavior<,>));
			config.AddOpenBehavior(typeof(RequestLoggingPipelineBehavior<,>));
			config.AddOpenBehavior(typeof(ValidationPipelineBehavior<,>));
		});

		services.AddValidatorsFromAssemblies(moduleAssemblies, includeInternalTypes: true);

		return services;
	}
}