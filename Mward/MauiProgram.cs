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

            // Register the FirebaseAuthService
            builder.Services.AddSingleton<IFirebaseAuthService, FirebaseAuthService>();

            return builder.Build();
        }
    }
}
