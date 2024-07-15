using Microsoft.Maui;
using Microsoft.Maui.Hosting;
using Mward.Services;

namespace Mward
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
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            // Register the MongoDB service
            builder.Services.AddSingleton<MongoDBService>();

            return builder.Build();
        }
    }
}
