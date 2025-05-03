using Microsoft.Extensions.Logging;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SftEngGP.Data;
using SftEngGP.Database.Data;
using SftEngGP.ViewModels;
using SftEngGP.Views;
using Syncfusion.Maui.Core.Hosting;


namespace SftEngGP
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            var a = Assembly.GetExecutingAssembly();
            
            builder.Services.AddDbContext<GpDbContext>(options =>
                options.UseSqlite("Server=192.168.0.13,1433;Database=gpdb;User Id=gpapp;Password=gp4pp$00;TrustServerCertificate=True;Encrypt=True;"));
            
            builder.Services.AddSingleton<SimulatedTimeService>();
            builder.Services.AddSingleton<SensorDataService>();

            builder.Services.AddSingleton<AdminDashboardViewModel>();
            builder.Services.AddSingleton<AdminDashboard>();

            builder.Services.AddSingleton<EnvScientistViewModel>();
            builder.Services.AddSingleton<EnvScientistPage>();
            
            builder.Services.AddSingleton<OpManagerViewModel>();
            builder.Services.AddSingleton<OpManagerPage>();

            builder.Services.AddSingleton<SensorsOverviewPage>();
            
            builder.Services.AddTransient<AllSensorsViewModel>();
            builder.Services.AddTransient<AllSensorsPage>();

            builder.Services.AddSingleton<AccountsOverviewViewModel>();
            
            builder.Services.AddTransient<SensorViewModel>();
            builder.Services.AddTransient<TrendsPage>();
            builder.Services.AddTransient<SensorPage>();
            
            builder.Services.AddSingleton(new SimulatedTimeService(DateTime.Parse("2025-02-01 00:00:00")));
            
            builder
                .UseMauiApp<App>().ConfigureSyncfusionCore()
                .UseMauiApp<App>()
                .UseMauiMaps()
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
