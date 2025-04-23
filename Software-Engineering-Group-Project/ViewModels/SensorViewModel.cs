using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using Java.Sql;
using SftEngGP.Database.Data;
using SftEngGP.Database.Models;

namespace SftEngGP.ViewModels;
/// <summary>
/// contains all the properties of a sensor
/// </summary>
public class SensorViewModel
{
    private GpDbContext _context;
    private Sensor _sensor;
    private Measurand _measurand;
    
    public int SensorId => _sensor.SensorId;
    public float Latitude => _sensor.Latitude;
    public string Longitude => _sensor.Longitude;
    public string SensorType => _sensor.SensorType;
    public int MeasurandId => _measurand.MeasurandId;
    public string QuantityType => _measurand.QuantityType;
    public string Quantity => _measurand.Quantity;
    public string Symbol => _measurand.Symbol;
    public string Unit => _measurand.Unit;
    public string MeasurmentFrequency => _measurand.MeasurmentFrequency;
    public ObservableCollection<SensorReading> SensorReadings { get; set; }

    public int MissingReadingCount => GetMissingReadingCount();

    public SensorViewModel(GpDbContext gpDbContext)
    {
        _context = gpDbContext;
        _sensor = new Sensor();
        _measurand = new Measurand();
        SensorReadings = new ObservableCollection<SensorReading>();
    }
    
    public SensorViewModel(GpDbContext gpDbContext, Sensor sensor)
    {
        _context = gpDbContext;
        _sensor = sensor;
        _measurand = _context.Measurands.Single(m => m.SensorId == _sensor.SensorId);
        SensorReadings = new ObservableCollection<SensorReading>(_context.Readings.Where(r => r.SensorId == _sensor.SensorId));
    }

    /// <summary>
    /// Verifies the accuracy of the collected data by determining how many missing readings a sensor has
    /// </summary>
    /// <returns>The count of missing readings of the sensor</returns>
    public int GetMissingReadingCount()
    {
        TimeSpan timeSpan = TimeSpan.FromHours(1);
        DateTimeOffset dateTimeOffset;
        if (MeasurmentFrequency == "Hourly")
        {
            timeSpan = TimeSpan.FromHours(1);
        }
        else if (MeasurmentFrequency == "Daily")
        {
            timeSpan = TimeSpan.FromDays(1);
        }

        DateTime timestamp = SensorReadings.First().Timestamp;

        int missedReadings = 0;
        
        foreach (SensorReading sensorReading in SensorReadings)
        {
            while (sensorReading.Timestamp > timestamp)
            {
                missedReadings++;
                timestamp = timestamp.Add(timeSpan);
            }

            timestamp = timestamp.Add(timeSpan);
        }

        return missedReadings;

    }
}