using App1.Shared.Infrastructure.Auth;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Identity.Web;

namespace App1.ApiService.Infrastructure.Extensions;

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
		services.AddMicrosoftIdentityWebApiAuthentication(configuration);

		services.AddCors(options =>
		{
			options.AddDefaultPolicy(policy =>
				                         policy.AllowAnyOrigin() //WithOrigins("https://localhost:7051")
				                               .AllowAnyMethod()
				                               .AllowAnyHeader());
		});

		return services;
	}

	internal static IServiceCollection AddAuthZ(this IServiceCollection services)
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
}