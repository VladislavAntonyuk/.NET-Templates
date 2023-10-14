using App1.Application.Configuration;
using App1.Infrastructure.WebApp.Business;
using App1.Infrastructure.WebApp.Data.Configuration;
using App1.WebApp.Components;
using App1.WebApp.Extensions;
using App1.WebApp.Models;
using Microsoft.AspNetCore.Localization;
using MudBlazor.Services;
using Toolbelt.Blazor.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddApplication();
builder.Services.AddInfrastructureData(builder.Configuration.GetConnectionString("Database"));
builder.Services.AddInfrastructureBusiness();

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddMudServices();
builder.Services.AddI18nText();
builder.Services.Configure<RequestLocalizationOptions>(options =>
{
	var supportedCultures = Enum.GetValues<Language>().Select(x => x.GetDescription()).ToArray();
	options.DefaultRequestCulture = new RequestCulture(supportedCultures.First());
	options.AddSupportedCultures(supportedCultures);
	options.AddSupportedUICultures(supportedCultures);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
