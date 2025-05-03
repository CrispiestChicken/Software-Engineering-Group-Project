using SftEngGP.Database.Data;
using SftEngGP.Database.Models;

namespace SftEngGP.Data;

public class SensorDataService
{
    private readonly GpDbContext _context;
    private readonly SimulatedTimeService _timeService;

    public WaterQuality? LatestWaterQuality { get; private set; }
    public AirQuality? LatestAirQuality { get; private set; }
    public Weather? LatestWeather { get; private set; }

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
        var date = DateOnly.FromDateTime(time);
        var t = TimeOnly.FromDateTime(time);

        LatestWaterQuality = _context.WaterQuality.FirstOrDefault(w => w.date == date && w.time == t);
        LatestAirQuality = _context.AirQuality.FirstOrDefault(a => a.date == date && a.time == t);
        LatestWeather = _context.Weather.FirstOrDefault(w => w.datetime == time);

        OnDataUpdated?.Invoke();
    }
}
