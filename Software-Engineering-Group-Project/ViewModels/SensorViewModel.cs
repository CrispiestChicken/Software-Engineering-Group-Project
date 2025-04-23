using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
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
}