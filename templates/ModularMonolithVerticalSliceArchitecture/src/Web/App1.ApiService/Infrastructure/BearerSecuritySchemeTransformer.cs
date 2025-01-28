﻿using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace App1.ApiService.Infrastructure;

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.OpenApi;
using Microsoft.OpenApi.Models;

internal sealed class BearerSecuritySchemeTransformer(IAuthenticationSchemeProvider authenticationSchemeProvider)
	: IOpenApiDocumentTransformer
{
	public async Task TransformAsync(OpenApiDocument document,
		OpenApiDocumentTransformerContext context,
		CancellationToken cancellationToken)
	{
		var authenticationSchemes = await authenticationSchemeProvider.GetAllSchemesAsync();
		if (authenticationSchemes.Any(authScheme => authScheme.Name == JwtBearerDefaults.AuthenticationScheme))
		{
			var requirements = new Dictionary<string, OpenApiSecurityScheme>
			{
				[JwtBearerDefaults.AuthenticationScheme] = new()
				{
					Type = SecuritySchemeType.Http,
					Scheme = JwtBearerDefaults.AuthenticationScheme,
					In = ParameterLocation.Header,
					BearerFormat = "Json Web Token"
				}
			};
			document.Components ??= new OpenApiComponents();
			document.Components.SecuritySchemes = requirements;
		}
	}
}