using Microsoft.Extensions.Logging;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SftEngGP.Database;
using SftEngGP.Database.Data;
using SftEngGP.ViewModels;
using SftEngGP.Views;


namespace SftEngGP
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            var a = Assembly.GetExecutingAssembly();

            builder.Services.AddDbContext<GpDbContext>();

            builder.Services.AddSingleton<AdminDashboardViewModel>();
            builder.Services.AddSingleton<AdminDashboard>();

            builder.Services.AddSingleton<EnvScientistViewModel>();
            builder.Services.AddSingleton<EnvScientistPage>();
            
            builder.Services.AddSingleton<OpManagerViewModel>();
            builder.Services.AddSingleton<OpManagerPage>();


            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
