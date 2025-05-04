using System;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.EntityFrameworkCore;
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
    private readonly SimulatedTimeService _timeService;

    [ObservableProperty]
    private ObservableCollection<SensorReading> latestReadings;

    [ObservableProperty] 
    private DateTime simulatedTime;


    /// <summary>
    /// Represents the ViewModel for managing and displaying the status and updates
    /// of various sensors including water, air, and weather sensors.
    /// </summary>
    public AllSensorsViewModel(SensorDataService dataService, SimulatedTimeService timeService)
    {
        _timeService = timeService;
        SimulatedTime = _timeService.SimulatedTime;
        
        LatestReadings = new ObservableCollection<SensorReading>(dataService.LatestSensorReadings);
        
        dataService.OnDataUpdated += () =>
        {
            MainThread.BeginInvokeOnMainThread(() =>
            {
                LatestReadings.Clear();
                foreach (var reading in dataService.LatestSensorReadings)
                {
                    LatestReadings.Add(reading);
                }

                NotifySensorPropertiesChanged();
            });
        };

        _timeService.OnTimeChanged += async time =>
        {
            await MainThread.InvokeOnMainThreadAsync(() => SimulatedTime = time);
        };
    }

    public string GetSensorStatus(string sensorType)
    {
        return LatestReadings.Any(r => r.Sensor.SensorType == sensorType) ? "Online" : "Offline";
    }

    public string GetLastUpdated(string sensorType)
    {
        var last = LatestReadings
            .Where(r => r.Sensor.SensorType == sensorType)
            .OrderByDescending(r => r.Timestamp)
            .FirstOrDefault();;
        
        return last != null ? last.Timestamp.ToString("yyyy-MM-dd HH:mm") : "N/A";
    }
    
    private void NotifySensorPropertiesChanged()
    {
        OnPropertyChanged(nameof(GetSensorStatus));
        OnPropertyChanged(nameof(GetLastUpdated));
    }
}
