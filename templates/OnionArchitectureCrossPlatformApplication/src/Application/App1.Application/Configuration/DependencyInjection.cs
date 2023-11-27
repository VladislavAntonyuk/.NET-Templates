namespace App1.Application.Configuration;

using System.Reflection;
using Behaviors;
using FluentValidation;
using Mediator;
using Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection
{
	public static void AddApplication(this IServiceCollection services)
	{
		var assembly = Assembly.GetExecutingAssembly();

		services.AddMediator(options => options.ServiceLifetime = ServiceLifetime.Scoped);
		services.AddScoped(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
		services.AddScoped(typeof(IPipelineBehavior<,>), typeof(PerformanceBehavior<,>));
		services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
		services.AddValidatorsFromAssembly(assembly);
	}
}