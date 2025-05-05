using Microsoft.EntityFrameworkCore;
using SftEngGP.Database.Data;
using SftEngGP.Database.Models;
using SftEngGP.ViewModels;
using SftEngGP.Models;
using System.Diagnostics;

namespace SftEngGP.Test;

public class BreachClassTest
{
    private DatabaseFixture _fixture;

    private List<Sensor> _sensors;

    private List<Incidence> _incidences;

    public BreachClassTest()
    {
        _fixture = new DatabaseFixture();

        _sensors = _fixture._testDbContext.Sensors.ToList();
        _incidences = _fixture._testDbContext.Incidences.ToList();

    }

    [Fact]
    public void BreachCreationSuccessful()
    {
        Assert.NotEmpty(_sensors);
        Assert.NotEmpty(_incidences);

        foreach (var incident in _incidences)
        {
            var sensor = _sensors.FirstOrDefault(s => s.SensorId == incident.SensorId);
            if (sensor != null)
            {
                var breach = new Breach(incident, sensor);
                Assert.NotNull(breach);
                Assert.Equal(incident.IncidenceType, breach.IncidenceType);
                Assert.Equal(sensor.Latitude, breach.Latitude);
                Assert.Equal(sensor.Longitude, breach.Longitude);
                Assert.Equal(incident.Alert, breach.Alert);
                Assert.Equal(incident.DateOfEvent, breach.DateOfEvent);
            }
        }
    }


}