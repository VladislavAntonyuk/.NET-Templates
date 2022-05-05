namespace App1.Infrastructure.WebApp.Business;

using App1.WebApp.Application;
using Application.Interfaces;
using Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection
{
	public static void AddInfrastructureBusiness(this IServiceCollection services)
	{
		services.AddScoped<IWebAppInterface, WebServiceClass1>();
		services.AddScoped<IServiceInterface1, ServiceClass1>();
	}
}