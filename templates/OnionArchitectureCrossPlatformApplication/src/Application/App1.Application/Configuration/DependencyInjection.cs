namespace App1.Application.Configuration;

using System.Reflection;
using Behaviors;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection
{
	public static void AddApplication(this IServiceCollection services)
	{
		var assembly = Assembly.GetExecutingAssembly();
		services.AddMediatR(configuration =>
		{
			configuration.RegisterServicesFromAssembly(assembly);
			configuration.AddOpenBehavior(typeof(UnhandledExceptionBehaviour<,>));
			configuration.AddOpenBehavior(typeof(PerformanceBehaviour<,>));
			configuration.AddOpenBehavior(typeof(ValidationBehavior<,>));
		});
		services.AddValidatorsFromAssembly(assembly);
		services.AddAutoMapper(assembly);
	}
}