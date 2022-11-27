namespace App1.Client;

using Application.Configuration;
using Infrastructure.Data.Repositories.Models;
using CommunityToolkit.Maui;
using Infrastructure.Business;
using Infrastructure.Data.Configuration;
using Microsoft.EntityFrameworkCore;
using ViewModels;
using Views;
using Microsoft.Extensions.Logging;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder.UseMauiApp<App>()
		       .ConfigureFonts(fonts =>
		       {
			       fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
			       fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			   });
		builder.UseMauiCommunityToolkit(options =>
		{
			options.SetShouldSuppressExceptionsInAnimations(true);
			options.SetShouldSuppressExceptionsInBehaviors(true);
			options.SetShouldSuppressExceptionsInConverters(true);
		});
		builder.Services.AddApplication();
		builder.Services.AddInfrastructureData(GetDatabaseConnectionString("App1"));
		builder.Services.AddInfrastructureBusiness();
		builder.Services.AddSingleton<MainViewModel>();
		builder.Services.AddSingleton<MainPage>();

#if DEBUG
		builder.Logging.AddDebug();
#endif

		var app = builder.Build();
		MigrateDb(app.Services);
		return app;
	}

	private static string GetDatabaseConnectionString(string filename)
	{
		return $"Filename={Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), filename)}.db";
	}

	private static void MigrateDb(IServiceProvider serviceProvider)
	{
		using var scope = serviceProvider.CreateScope();
		var factory = scope.ServiceProvider.GetRequiredService<IDbContextFactory<ApplicationContext>>();
		using var context = factory.CreateDbContext();
		context.Database.Migrate();
	}
}