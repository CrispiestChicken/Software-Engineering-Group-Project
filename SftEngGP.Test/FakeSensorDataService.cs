using SftEngGP.Data;
using SftEngGP.Database.Data;
using SftEngGP.Database.Models;

namespace SftEngGP.Test;

public class FakeSensorDataService : SensorDataService
{
    public FakeSensorDataService(GpDbContext context, SimulatedTimeService timeService)
        : base(context, timeService) { }

    public void SetLatestData(WaterQuality water, AirQuality air, Weather weather)
    {
        typeof(SensorDataService)
            .GetProperty(nameof(LatestWaterQuality))!
            .SetValue(this, water);

        typeof(SensorDataService)
            .GetProperty(nameof(LatestAirQuality))!
            .SetValue(this, air);

        typeof(SensorDataService)
            .GetProperty(nameof(LatestWeather))!
            .SetValue(this, weather);
    }
}
