namespace App1.Infrastructure.WebApp.Data
{
    using App1.Domain.Interfaces;
    using Microsoft.Extensions.DependencyInjection;
    using System;

    public static class DependencyInjection
    {
        public static void AddInfrastructureData(this IServiceCollection services)
        {
            if (services is null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            services.AddScoped<IDomainInterface1, DataClass1>();
        }
    }
}