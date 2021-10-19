using App1.Infrastructure.Mobile.Business;
using App1.Infrastructure.Mobile.Data;
using Microsoft.Maui.Controls.Hosting;
using Microsoft.Maui.Hosting;

namespace App1.Mobile
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()                
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

            builder.Services.AddInfrastructureData();
            builder.Services.AddInfrastructureBusiness();
            return builder.Build();
        }
    }
}