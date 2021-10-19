namespace App1.Infrastructure.WebApp.Business
{
    using App1.Services.Interfaces;
    using Microsoft.Extensions.DependencyInjection;
    using System;

    public static class DependencyInjection
    {
        public static void AddInfrastructureBusiness(this IServiceCollection services)
        {
            if (services is null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            services.AddScoped<IServiceInterface1, ServiceClass1>();
        }
    }
}