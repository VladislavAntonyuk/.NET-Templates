﻿namespace App1.Web.Services;

using Microsoft.Identity.Web;

public record Module1Response(Guid Id, string Prop1);

public class App1ApiClient(HttpClient httpClient, MicrosoftIdentityConsentAndConditionalAccessHandler handler)
{
	public async Task<List<Module1Response>> GetModule1s(CancellationToken cancellationToken)
	{
		return await httpClient.GetFromJsonAsync<List<Module1Response>>("Module1s", cancellationToken).Safe([], handler.HandleException) ?? [];
	}

	public async Task DeleteModule1(Guid module1Id, CancellationToken cancellationToken)
	{
		// admin delete
		await httpClient.DeleteAsync($"Module1s/{module1Id}", cancellationToken).Safe(handler.HandleException);
	}

	public Task UpdateModule1(Guid id, CancellationToken cancellationToken)
	{
		var request = new
		{
			
		};
		return httpClient.PutAsJsonAsync($"Module1s/{id}", request, cancellationToken).Safe(handler.HandleException);
	}
}