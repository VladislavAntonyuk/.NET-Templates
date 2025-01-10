namespace App1.Web;

using System.Net.Http.Headers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.Identity.Web;

public class MicrosoftIdentityModule1AuthenticationMessageHandler(
	ITokenAcquisition tokenAcquisition,
	IOptionsMonitor<MicrosoftIdentityAuthenticationMessageHandlerOptions> namedMessageHandlerOptions,
	string? serviceName = null)
	: MicrosoftIdentityAuthenticationBaseMessageHandler(tokenAcquisition, namedMessageHandlerOptions, serviceName)
{
	private readonly IOptionsMonitor<MicrosoftIdentityAuthenticationMessageHandlerOptions> namedMessageHandlerOptions = namedMessageHandlerOptions;

	/// <inheritdoc />
	protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
		CancellationToken cancellationToken)
	{
		var authResult = await TokenAcquisition
							   .GetAccessTokenForUserAsync(namedMessageHandlerOptions.CurrentValue.GetScopes())
							   .ConfigureAwait(false);

		request.Headers.Authorization = new AuthenticationHeaderValue(JwtBearerDefaults.AuthenticationScheme, authResult);

		return await base.SendAsync(request, cancellationToken).ConfigureAwait(false);
	}
}