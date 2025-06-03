using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;

namespace App1.WebApp;

public class GraphApiAuthorizationMessageHandler : AuthorizationMessageHandler
{
	public GraphApiAuthorizationMessageHandler(
		IConfiguration configuration,
		IAccessTokenProvider provider,
		NavigationManager navigationManager)
		: base(provider, navigationManager)
	{
		var baseAddress = configuration["ApiBaseUrl"];
		ArgumentNullException.ThrowIfNull(baseAddress);
		var scopes = configuration.GetValue<string[]>("AzureAd:DefaultAccessTokenScopes");
		ArgumentNullException.ThrowIfNull(scopes);
		ConfigureHandler(
			authorizedUrls: [baseAddress],
			scopes: scopes);
	}
}