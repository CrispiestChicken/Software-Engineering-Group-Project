using Microsoft.EntityFrameworkCore;
using Moq;
using SftEngGP.Data;
using SftEngGP.Database.Data;
using SftEngGP.Database.Models;
using SftEngGP.ViewModels;

namespace SftEngGP.Test;

public class AltAllSensorsViewModelTests
{
    [Fact]
    public void Constructor_InitializesPropertiesCorrectly()
    {
        var options = new DbContextOptionsBuilder<GpDbContext>()
            .UseInMemoryDatabase("TestDb")
            .Options;
        var context = new GpDbContext(options);

        var fakeTime = new DateTime(2025, 1, 1, 12, 0, 0);
        var timeService = new SimulatedTimeService(fakeTime);

        var sensor = new Sensor { SensorId = 1, Latitude = 0, Longitude = 0, SensorType = "Air" };
        context.Sensors.Add(sensor);
        context.SaveChanges();

        var reading = new SensorReading
        {
            ReadingId = 1,
            SensorId = sensor.SensorId,
            Timestamp = fakeTime,
            SensorValue = 42.0f,
            Sensor = sensor
        };

        var fakeDataService = new FakeSensorDataService(context, timeService);
        fakeDataService.SetLatestData(new List<SensorReading> { reading });

        var viewModel = new AllSensorsViewModel(fakeDataService, timeService);

        Assert.Equal(fakeTime, viewModel.SimulatedTime);
        Assert.Single(viewModel.LatestReadings);
        Assert.Equal("Air", viewModel.LatestReadings.First().Sensor.SensorType);
    }
}