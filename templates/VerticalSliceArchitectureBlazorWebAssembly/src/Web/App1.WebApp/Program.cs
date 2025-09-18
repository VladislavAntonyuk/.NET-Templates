using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using App1.WebApp;
using App1.WebApp.Infrastructure.Extensions;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddMudServices();

builder.Services.AddHttpClient("MyBackendApi", (sp, client) =>
       {
	       var baseAddress = sp.GetRequiredService<IConfiguration>()["ApiBaseUrl"];
		   ArgumentNullException.ThrowIfNull(baseAddress);
		   client.BaseAddress = new Uri(baseAddress);
	   })
	   .AddHttpMessageHandler<GraphApiAuthorizationMessageHandler>();

builder.Services.AddCascadingAuthenticationState();
builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("MyBackendApi"));

builder.Services.AddAuth(builder.Configuration);

builder.Services.AddScoped<GraphApiAuthorizationMessageHandler>();

await builder.Build().RunAsync();