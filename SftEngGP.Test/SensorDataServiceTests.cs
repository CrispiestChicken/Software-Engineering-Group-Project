using System;
using Microsoft.EntityFrameworkCore;
using Moq;
using SftEngGP.Data;
using SftEngGP.Database.Data;
using SftEngGP.Database.Models;
using Xunit;

namespace SftEngGP.Test;

public class SensorDataServiceTests
{
    private GpDbContext GetMockedContext()
    {
        var options = new DbContextOptionsBuilder<GpDbContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

        var context = new GpDbContext(options);

        context.WaterQuality.Add(new WaterQuality
        {
            date = new DateOnly(2023, 1, 1),
            time = new TimeOnly(12, 0),
            nitrate = 1.5f
        });

        context.AirQuality.Add(new AirQuality
        {
            date = new DateOnly(2023, 1, 1),
            time = new TimeOnly(12, 0),
            nitrogen_dioxide = 10.0f
        });

        context.Weather.Add(new Weather
        {
            datetime = new DateTime(2023, 1, 1, 12, 0, 0),
            temperature = 25.0f
        });

        context.SaveChanges();
        return context;
    }

    [Fact]
    public void LoadSensorReadings_Fires_On_The_Hour()
    {
        var context = GetMockedContext();
        var simulatedTimeService = new TestableSimulatedTimeService(new DateTime(2023, 1, 1, 11, 0, 0));
        var service = new SensorDataService(context, simulatedTimeService);

        bool eventFired = false;
        service.OnDataUpdated += () => eventFired = true;
        
        simulatedTimeService.TriggerTimeUpdate();
        
        Assert.True(eventFired);
        Assert.NotNull(service.LatestWaterQuality);
        Assert.Equal(1.5f, service.LatestWaterQuality.nitrate);
    }

    [Fact]
    public void LoadSensorReadings_DoesNotFire_OffTheHour()
    {
        var context = GetMockedContext();
        var simulatedTimeService = new TestableSimulatedTimeService(new DateTime(2023, 1, 1, 12, 0, 0));
        var service = new SensorDataService(context, simulatedTimeService);

        bool eventFired = false;
        service.OnDataUpdated += () => eventFired = true;

        var offHourTime = new DateTime(2023, 1, 1, 12, 30, 0);
        
        simulatedTimeService.TriggerTimeUpdate();
        
        Assert.False(eventFired);
        Assert.Null(service.LatestWaterQuality);
        Assert.Null(service.LatestAirQuality);
        Assert.Null(service.LatestWeather);
    }
}