namespace App1.Infrastructure.Mobile.Business;

using Application.Interfaces;
using Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection
{
	public static void AddInfrastructureBusiness(this IServiceCollection services)
	{
		services.AddScoped<IServiceInterface1, ServiceClass1>();
	}
}