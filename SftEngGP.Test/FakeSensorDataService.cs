using SftEngGP.Data;
using SftEngGP.Database.Data;
using SftEngGP.Database.Models;

namespace SftEngGP.Test;

public class FakeSensorDataService : SensorDataService
{
    public FakeSensorDataService(GpDbContext context, SimulatedTimeService timeService)
        : base(context, timeService) { }

    public void SetLatestData(List<SensorReading> readings)
    {
        typeof(SensorDataService)
            .GetProperty(nameof(LatestSensorReadings))!
            .SetValue(this, readings);
    }
}
