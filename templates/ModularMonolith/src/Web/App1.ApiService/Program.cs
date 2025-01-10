using System.Reflection;
using App1.ApiService.Extensions;
using App1.ApiService.Infrastructure;
using App1.Common.Application;
using App1.Common.Infrastructure;
using App1.Common.Presentation.Endpoints;
using App1.Modules.Module1s.Infrastructure;
using App1.Modules.Module2s.Infrastructure;
using App1.ServiceDefaults;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add service defaults & Aspire components.
builder.AddServiceDefaults();

builder.Services.AddProblemDetails();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApi(options =>
{
	options.AddDocumentTransformer<BearerSecuritySchemeTransformer>();
});

Assembly[] moduleApplicationAssemblies =
[
	App1.Modules.Module1s.Application.AssemblyReference.Assembly,
	App1.Modules.Module2s.Application.AssemblyReference.Assembly
];

builder.Services.AddApplication(moduleApplicationAssemblies);

builder.AddInfrastructure([
	App1.Modules.Module2s.Infrastructure.Module2sModule.ConfigureConsumers
]);

builder.Configuration.AddModuleConfiguration(["module1s", "module2s"]);

builder.AddModule1sModule();
builder.AddModule2sModule();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseExceptionHandler();

if (app.Environment.IsDevelopment())
{
	await app.ApplyMigrations();
	app.MapOpenApi();
	app.MapScalarApiReference();
}

app.UseAuthentication();
app.UseAuthorization();

app.MapEndpoints();
app.MapDefaultEndpoints();

await app.RunAsync();

public partial class Program
{
	protected Program() { }
};