namespace App1;

using App1Shared;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder.UseMauiApp<App>();

		builder.Services.AddMauiBlazorWebView();
		builder.Services.AddShared();

#if DEBUG
		builder.Services.AddBlazorWebViewDeveloperTools();
#endif

		return builder.Build();
	}
}