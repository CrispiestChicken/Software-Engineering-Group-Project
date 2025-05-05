using Microsoft.Extensions.Logging;
using System.Reflection;
using CommunityToolkit.Maui;
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
            
            // Add DbContext with SQLite configuration
            builder.Services.AddDbContext<GpDbContext>(options =>
                options.UseSqlite("Server=ip,port;Database=gpdb;User Id=gpapp;Password=gp4pp$00;TrustServerCertificate=True;Encrypt=True;"));
            
            // Add transient services for other classes
            builder.Services.AddTransient<SimulatedTimeService>(_ => new SimulatedTimeService(DateTime.Parse("2025-01-31 23:50:00")));
            builder.Services.AddTransient<SensorDataService>();

            // Add view models and pages for dependency injection
            builder.Services.AddTransient<AdminDashboardViewModel>();
            builder.Services.AddTransient<AdminDashboard>();
            
            builder.Services.AddTransient<EnvScientistViewModel>();
            builder.Services.AddTransient<EnvScientistPage>();
            
            builder.Services.AddTransient<OpManagerViewModel>();
            builder.Services.AddTransient<OpManagerPage>();

            builder.Services.AddTransient<SensorsOverviewPage>();
            
            builder.Services.AddTransient<AllSensorsViewModel>();
            builder.Services.AddTransient<AllSensorsPage>();

            builder.Services.AddSingleton<AccountsOverviewViewModel>(); // You may want to reconsider Singleton here if this view model holds state tied to specific pages
            builder.Services.AddTransient<AllTablesViewModel>();
            builder.Services.AddTransient<AllTablesPage>();

            builder.Services.AddTransient<SensorViewModel>();
            builder.Services.AddTransient<TrendsPage>();
            builder.Services.AddTransient<SensorPage>();
            
            builder.Services.AddTransient<TableViewModel>();
            builder.Services.AddTransient<TableRowViewModel>();
            
            builder.Services.AddTransient<AppShell>();
            builder.Services.AddSingleton<App>();

            // Add the Account Creation ViewModel and Page
            builder.Services.AddTransient<AccountCreationViewModel>();
            builder.Services.AddTransient<AccountCreationPage>();
            
            // Add the Login ViewModel and Page
            builder.Services.AddTransient<LoginViewModel>();
            builder.Services.AddTransient<LoginPage>();
            
            // Add the Maintenance Creation ViewModel and Page
            builder.Services.AddTransient<MaintenanceCreationViewModel>();
            builder.Services.AddTransient<MaintenanceCreationPage>();
            
            // Add the Maintenance Overview ViewModel and Page
            builder.Services.AddTransient<MaintenanceOverviewViewModel>();
            builder.Services.AddTransient<MaintenanceOverviewPage>();
            
            // Add the Map ViewModel and Page
            builder.Services.AddTransient<MapViewModel>();
            builder.Services.AddTransient<MapPage>();

            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
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
