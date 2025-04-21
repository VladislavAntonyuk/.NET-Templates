using App1.Web.Services.Auth;
using App1.Web.Services.User;

namespace App1.Web.Services;

using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Localization;
using Microsoft.Identity.Web;
using Microsoft.Identity.Web.UI;
using MudBlazor.Services;
using Toolbelt.Blazor.Extensions.DependencyInjection;
using Toolbelt.Blazor.I18nText;
using Constants = Microsoft.Identity.Web.Constants;
using MicrosoftIdentityModule1AuthenticationMessageHandler = MicrosoftIdentityModule1AuthenticationMessageHandler;

public static class ServiceExtensions
{
	public static void AddBlazor(this IServiceCollection services)
	{
		services.AddRazorPages();
		services.AddControllersWithViews().AddMicrosoftIdentityUI();
		services.AddMudServices();
		services.AddTranslations();
		services.AddLogging();
		services.AddRazorComponents().AddInteractiveServerComponents().AddMicrosoftIdentityConsentHandler();
	}

	public static void AddAuth(this IServiceCollection services, IConfiguration configuration)
	{
		var scopes = configuration.GetRequiredSection("App1ApiClient:Scopes").Get<string>()?.Split(' ');
		services.AddMicrosoftIdentityWebAppAuthentication(configuration, Constants.AzureAdB2C)
				.EnableTokenAcquisitionToCallDownstreamApi(scopes)
				.AddDistributedTokenCaches();

		services.AddCascadingAuthenticationState();
		services.AddAuthZ();
	}
	internal static IServiceCollection AddAuthZ(this IServiceCollection services)
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
	
	public static void AddModule1Services(this IServiceCollection services, IConfiguration configuration)
	{
		services.AddHttpContextAccessor();
		services.AddScoped<ICurrentUserService, CurrentUserService>();
	}

	public static void AddApp1Services(this IServiceCollection services, IConfiguration configuration)
	{
		var baseUrl = configuration.GetRequiredSection("App1ApiClient:BaseUrl").Get<Uri>();
		services.AddOptions<MicrosoftIdentityAuthenticationMessageHandlerOptions>()
				.Bind(configuration.GetSection("App1ApiClient"));
		services.AddTransient<MicrosoftIdentityModule1AuthenticationMessageHandler>();
		services.AddHttpClient<App1ApiClient>(httpClient =>
				{
					httpClient.BaseAddress = baseUrl;
				})
				.AddHttpMessageHandler<MicrosoftIdentityModule1AuthenticationMessageHandler>();
	}

	private static void AddTranslations(this IServiceCollection services)
	{
		services.AddI18nText(options => options.PersistenceLevel = PersistanceLevel.Cookie);
		services.Configure<RequestLocalizationOptions>(options =>
		{
			string[] supportedCultures = ["en-US"];
			options.DefaultRequestCulture = new RequestCulture(supportedCultures[0]);
			options.AddSupportedCultures(supportedCultures);
			options.AddSupportedUICultures(supportedCultures);
		});
	}
}