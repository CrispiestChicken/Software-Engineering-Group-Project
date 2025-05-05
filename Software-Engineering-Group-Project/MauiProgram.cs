using Microsoft.Extensions.Logging;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SftEngGP.Data;
using SftEngGP.Database.Data;
using SftEngGP.ViewModels;
using SftEngGP.Views;
using Syncfusion.Maui.Core.Hosting;
using CommunityToolkit.Maui;


namespace SftEngGP
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            
            builder.Services.AddDbContext<GpDbContext>(options =>
                options.UseSqlite("Server=ip,port;Database=gpdb;User Id=gpapp;Password=gp4pp$00;TrustServerCertificate=True;Encrypt=True;"));
            
            builder.Services.AddSingleton(new SimulatedTimeService(DateTime.Parse("2025-01-31 23:50:00")));
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
            
            builder.Services.AddSingleton<AllTablesViewModel>();
            builder.Services.AddSingleton<AllTablesPage>();
            builder.Services.AddTransient<TableViewModel>();
            builder.Services.AddTransient<TableRowViewModel>();
            
            builder.Services.AddSingleton<AppShell>();
            builder.Services.AddSingleton<App>();
            
            builder
                .UseMauiApp<App>()
                .ConfigureSyncfusionCore()
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
