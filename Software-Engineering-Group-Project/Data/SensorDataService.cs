using Microsoft.EntityFrameworkCore;
using SftEngGP.Database.Data;
using SftEngGP.Database.Models;

namespace SftEngGP.Data;

/// <summary>
/// A service responsible for managing and retrieving sensor data, specifically water quality, air quality,
/// and weather information. This class integrates with the database context and simulated time service
/// to ensure data is updated and loaded appropriately when time changes occur.
/// </summary>
public class SensorDataService
{
    private readonly GpDbContext _context;
    private readonly SimulatedTimeService _timeService;

    public List<SensorReading> LatestSensorReadings { get; private set; } = new();

    public event Action? OnDataUpdated;


    /// <summary>
    /// A service to manage and retrieve sensor data for water quality, air quality, and weather.
    /// Integrates with a database context and a simulated time service to fetch and update sensor data.
    /// </summary>
    public SensorDataService(GpDbContext context, SimulatedTimeService timeService)
    {
        _context = context;
        _timeService = timeService;

        _timeService.OnTimeChanged += time =>
        {
            if (time.Minute == 0)
            {
                Console.WriteLine("Checking sensors...");
                _ = Task.Run(() => LoadSensorReadings(time));
            }
        };
    }

    private void LoadSensorReadings(DateTime time)
    {
        
        List<SensorReading> latest = _context.SensorReadings
            .GroupBy(r => new { r.SensorId, r.MeasurementType })
            .Select(g => g.OrderByDescending(r => r.Timestamp).FirstOrDefault())
            .Include(r => r!.Sensor)
            .ToList();
        
        LatestSensorReadings = latest;
        OnDataUpdated?.Invoke();
    }
}
