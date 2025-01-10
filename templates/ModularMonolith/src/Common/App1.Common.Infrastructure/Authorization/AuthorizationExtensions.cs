namespace App1.Common.Infrastructure.Authorization;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;

public static class PolicyConstants
{
	public const string AdministratorPolicy = "IsAdministrator";
}

internal static class AuthorizationExtensions
{
	internal static IServiceCollection AddJwtAuthorizationInternal(this IServiceCollection services)
	{
		services.AddSingleton<IAuthorizationHandler, AdministratorAuthorizationHandler>();
		services.AddAuthorization(options =>
		{
			var administratorOrHigherPolicyBuilder = new AuthorizationPolicyBuilder().AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme);
			administratorOrHigherPolicyBuilder.Requirements.Add(new AdministratorAuthorizationRequirement());
			options.AddPolicy(PolicyConstants.AdministratorPolicy, administratorOrHigherPolicyBuilder.Build());
		});

		return services;
	}

	internal static IServiceCollection AddOpenIdAuthorizationInternal(this IServiceCollection services)
	{
		services.AddSingleton<IAuthorizationHandler, AdministratorAuthorizationHandler>();
		services.AddAuthorization(options =>
		{
			var administratorOrHigherPolicyBuilder = new AuthorizationPolicyBuilder().AddAuthenticationSchemes(OpenIdConnectDefaults.AuthenticationScheme);
			administratorOrHigherPolicyBuilder.Requirements.Add(new AdministratorAuthorizationRequirement());
			options.AddPolicy(PolicyConstants.AdministratorPolicy, administratorOrHigherPolicyBuilder.Build());
		});

		return services;
	}
}