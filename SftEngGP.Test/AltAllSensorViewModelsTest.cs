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

        var expectedWater = new WaterQuality { date = DateOnly.FromDateTime(fakeTime), time = TimeOnly.FromDateTime(fakeTime) };
        var expectedAir = new AirQuality { date = DateOnly.FromDateTime(fakeTime), time = TimeOnly.FromDateTime(fakeTime) };
        var expectedWeather = new Weather { datetime = fakeTime };

        var fakeDataService = new FakeSensorDataService(context, timeService);
        fakeDataService.SetLatestData(expectedWater, expectedAir, expectedWeather);

        var viewModel = new AllSensorsViewModel(fakeDataService, timeService, context);

        Assert.Equal(fakeTime, viewModel.SimulatedTime);
        Assert.Equal(expectedWater, viewModel.CurrentWaterQuality);
        Assert.Equal(expectedAir, viewModel.CurrentAirQuality);
        Assert.Equal(expectedWeather, viewModel.CurrentWeather);
    }
}