using System.Collections.ObjectModel;
using SftEngGP.Database.Data;
using SftEngGP.Database.Models;

namespace SftEngGP.ViewModels;
/// <summary>
/// receives the properties needed to display a trend graph of thee readings of a given sensor
/// </summary>
public class TrendsViewModel
{
    private GpDbContext _context;

    public ObservableCollection<SensorReading> SensorReadings { get; set; }

    public TrendsViewModel(GpDbContext gpDbContext)
    {
        _context = gpDbContext;
        SensorReadings = GetTrendPropeties(2);
    }
    
    public TrendsViewModel(GpDbContext gpDbContext, int SensorId)
    {
        _context = gpDbContext;
        SensorReadings = GetTrendPropeties(SensorId);
    }

    /// <summary>
    /// Recieves the properties needed for a sensor reading trend graph
    /// </summary>
    /// <param name="SensorId">The id of the sensor</param>
    /// <returns>A List cotaining all of the readings beloning to the selected sensor</returns>
    public ObservableCollection<SensorReading> GetTrendPropeties(int SensorId)
    {
        return new ObservableCollection<SensorReading>(_context.Readings.Where(r => r.SensorId == SensorId));
        
    }

}