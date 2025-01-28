namespace App1.Common.Infrastructure.Authentication;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Identity.Web;

internal static class AuthenticationExtensions
{
	internal static IServiceCollection AddAuthenticationInternal(this IServiceCollection services,
		IConfiguration configuration)
	{
		services.AddMicrosoftIdentityWebApiAuthentication(configuration, Constants.AzureAdB2C);

		return services;
	}
}