using App1.Shared.Infrastructure.Auth;
using Microsoft.AspNetCore.Authorization;

namespace App1.WebApp.Infrastructure.Extensions;

internal static class AuthExtensions
{
	internal static IServiceCollection AddAuth(this IServiceCollection services, IConfiguration configuration)
	{
		services
			.AddAuthN(configuration)
			.AddAuthZ();
		
		return services;
	}

	internal static IServiceCollection AddAuthN(this IServiceCollection services, IConfiguration configuration)
	{
		services.AddCascadingAuthenticationState();
		services.AddMsalAuthentication(options =>
		{
			configuration.Bind("AzureAd", options.ProviderOptions);
		});

		return services;
	}

	internal static IServiceCollection AddAuthZ(this IServiceCollection services)
	{
		services.AddSingleton<IAuthorizationHandler, AdministratorAuthorizationHandler>();

		services.AddAuthorizationCore(options =>
		{
			var administratorOrHigherPolicyBuilder = new AuthorizationPolicyBuilder().AddAuthenticationSchemes("Bearer");
			administratorOrHigherPolicyBuilder.Requirements.Add(new AdministratorAuthorizationRequirement());
			options.AddPolicy(PolicyConstants.AdministratorPolicy, administratorOrHigherPolicyBuilder.Build());
		});

		return services;
	}
}