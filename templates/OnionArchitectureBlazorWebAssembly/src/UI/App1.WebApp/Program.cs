using App1.Application.Configuration;
using App1.Infrastructure.Business;
using App1.Infrastructure.Data.Configuration;
using App1.WebApp;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using Toolbelt.Blazor.Extensions.DependencyInjection;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.Services.AddApplication();
builder.Services.AddInfrastructureData();
builder.Services.AddInfrastructureBusiness();

builder.Services.AddMudServices();
builder.Services.AddI18nText();

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://fakestoreapi.com/") });

await builder.Build().RunAsync();