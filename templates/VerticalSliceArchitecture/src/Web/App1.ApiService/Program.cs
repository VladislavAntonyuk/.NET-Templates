using App1.ApiService.Application.Module1;
using App1.ApiService.Infrastructure;
using App1.ApiService.Infrastructure.Auth;
using App1.ApiService.Infrastructure.Database;
using App1.ApiService.Infrastructure.Extensions;
using App1.ServiceDefaults;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add service defaults & Aspire components.
builder.AddServiceDefaults();

builder.AddSqlServerDbContext<Module1sDbContext>("database");

builder.Services.AddProblemDetails();
builder.AddModule1s();
builder.Services.AddAuth(builder.Configuration);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApi(options =>
{
	options.AddDocumentTransformer<BearerSecuritySchemeTransformer>();
});

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

app.MapModule1Routes();

await app.RunAsync();