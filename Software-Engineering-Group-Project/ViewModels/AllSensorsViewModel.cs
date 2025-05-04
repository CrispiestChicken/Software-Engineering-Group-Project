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

    /// <summary>
    /// Determines the status of a sensor based on its type by evaluating the most recent sensor readings.
    /// </summary>
    /// <param name="sensorType">The type of the sensor whose status is to be checked.</param>
    /// <returns>A string indicating whether the sensor is "Online" if a recent reading exists, or "Offline" otherwise.</returns>
    public string GetSensorStatus(string sensorType)
    {
        return LatestReadings.Any(r => r.Sensor.SensorType == sensorType) ? "Online" : "Offline";
    }

    /// <summary>
    /// Retrieves the most recent update timestamp for a specified sensor type.
    /// </summary>
    /// <param name="sensorType">The type of the sensor whose last updated timestamp is to be retrieved.</param>
    /// <returns>
    /// A string representing the timestamp of the latest reading for the specified sensor type
    /// in the "yyyy-MM-dd HH:mm" format, or "N/A" if no readings are available.
    /// </returns>
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
