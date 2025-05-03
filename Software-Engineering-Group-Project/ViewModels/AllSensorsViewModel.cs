using System;
using CommunityToolkit.Mvvm.ComponentModel;
using SftEngGP.Data;
using SftEngGP.Database.Data;
using SftEngGP.Database.Models;

namespace SftEngGP.ViewModels;

/// <summary>
/// Represents the ViewModel responsible for managing and providing information
/// regarding the status and last updated timestamps of various sensors, including
/// water, air, and weather sensors. This class is designed to ensure real-time
/// updates and synchronization of related data for display purposes.
/// </summary>
public partial class AllSensorsViewModel : ObservableObject
{
    private readonly GpDbContext _context;
    private readonly SimulatedTimeService _timeService;

    [ObservableProperty]
    private WaterQuality? currentWaterQuality;

    [ObservableProperty]
    private AirQuality? currentAirQuality;

    [ObservableProperty]
    private Weather? currentWeather;

    [ObservableProperty] 
    private DateTime simulatedTime;

    public string WaterSensorStatus => CurrentWaterQuality != null ? "Online" : "Offline";
    public string AirSensorStatus => CurrentAirQuality != null ? "Online" : "Offline";
    public string WeatherSensorStatus => CurrentWeather != null ? "Online" : "Offline";

    public string WaterLastUpdated => CurrentWaterQuality != null ? $"{CurrentWaterQuality.date} {CurrentWaterQuality.time}" : "N/A";
    public string AirLastUpdated => CurrentAirQuality != null ? $"{CurrentAirQuality.date} {CurrentAirQuality.time}" : "N/A";
    public string WeatherLastUpdated => CurrentWeather != null ? CurrentWeather.datetime.ToString("yyyy-MM-dd HH:mm") : "N/A";


    /// <summary>
    /// Represents the ViewModel for managing and displaying the status and updates
    /// of various sensors including water, air, and weather sensors.
    /// </summary>
    public AllSensorsViewModel(SensorDataService dataService, SimulatedTimeService timeService, GpDbContext context)
    {
        _timeService = timeService;
        _context = context;

        SimulatedTime = _timeService.SimulatedTime;

        CurrentWaterQuality = dataService.LatestWaterQuality;
        CurrentAirQuality = dataService.LatestAirQuality;
        CurrentWeather = dataService.LatestWeather;
        
        dataService.OnDataUpdated += () => UpdateData(dataService);

        _timeService.OnTimeChanged += async time =>
        {
            await MainThread.InvokeOnMainThreadAsync(() => SimulatedTime = time);
        };
    }

    private void UpdateData(SensorDataService dataService)
    {
        Console.WriteLine("Data updating...");
        CurrentWaterQuality = dataService.LatestWaterQuality;
        CurrentAirQuality = dataService.LatestAirQuality;
        CurrentWeather = dataService.LatestWeather;
        NotifySensorPropertiesChanged();
    }
    
    private void NotifySensorPropertiesChanged()
    {
        OnPropertyChanged(nameof(WaterSensorStatus));
        OnPropertyChanged(nameof(AirSensorStatus));
        OnPropertyChanged(nameof(WeatherSensorStatus));
        OnPropertyChanged(nameof(WaterLastUpdated));
        OnPropertyChanged(nameof(AirLastUpdated));
        OnPropertyChanged(nameof(WeatherLastUpdated));
    }
}
