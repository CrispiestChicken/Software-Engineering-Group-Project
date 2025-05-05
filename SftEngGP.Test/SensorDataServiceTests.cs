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
    [Fact]
    public void LoadSensorReadings_AddsExpectedReadings()
    {
        var options = new DbContextOptionsBuilder<GpDbContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;
    
        var context = new GpDbContext(options);

        var fakeTime = new DateTime(2023, 1, 1, 11, 59, 0);
        var sensor = new Sensor { SensorId = 1, Latitude = 0, Longitude = 0, SensorType = "Water" };
        context.Add(sensor);

        var reading = new SensorReading
        {
            ReadingId = 1,
            SensorId = sensor.SensorId,
            Timestamp = fakeTime,
            SensorValue = 3.5f,
            Sensor = sensor,
            MeasurementType = "Nitrate"
        };
        context.SensorReadings.Add(reading);
        context.SaveChanges();
    
        var timeService = new TestableSimulatedTimeService(reading.Timestamp);
        var service = new SensorDataService(context, timeService);

        bool eventFired = false;
        service.OnDataUpdated += () => eventFired = true;
        
        timeService.SetTime(new DateTime(2023, 1, 1, 12, 0, 0));
        timeService.TriggerTimeUpdate();

        Assert.True(eventFired);
        Assert.Single(service.LatestSensorReadings);
        Assert.Equal(3.5f, service.LatestSensorReadings.First().SensorValue);
    }

}