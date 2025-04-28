using Microsoft.EntityFrameworkCore;
using SftEngGP.Database.Data;
using SftEngGP.Database.Models;

namespace SftEngGP.Test;

public class DatabaseFixture 
{
    internal TestGPDbContext? _testDbContext { get; private set; }
    private bool seeded;
    
    
    public DatabaseFixture()
    {
        _testDbContext = new TestGPDbContext();

        _testDbContext.Database.EnsureDeleted();
        _testDbContext.Database.EnsureCreated();
        _testDbContext.Database.OpenConnection();
        _testDbContext.Database.Migrate();
    }
    
    internal void Seed()
    {
        if (!seeded)
        {
                Sensor sensor = new Sensor();
            sensor.SensorType = "Air quality";
            sensor.Latitude = 1.1F;
            sensor.Longitude = 2.2F;

                _testDbContext.Sensors.Add(sensor);
            _testDbContext.SaveChanges();

                Measurand measurand = new Measurand();
            measurand.Frequency = "Hourly";
            measurand.SensorId = _testDbContext.Sensors.First().SensorId;
            measurand.QuantityType = "Nitrogen dioxide";
            measurand.Quantity = "microgrammes per cubic metre";
            measurand.Symbol = "NO2";
            measurand.Unit = "ug/m3";

                _testDbContext.Measurands.Add(measurand);
            _testDbContext.SaveChanges();

                FrequencyOffset frequencyOffset = new FrequencyOffset();
            
            frequencyOffset.Frequency = "Hourly";
            frequencyOffset.TimeDifference = new TimeSpan(1, 0, 0);
            frequencyOffset.DateDifference = 0;

                _testDbContext.FrequencyOffsets.Add(frequencyOffset);
            _testDbContext.SaveChanges();
            
            SensorReading sensorReading = new SensorReading();

                sensorReading.SensorId = _testDbContext.Sensors.First().SensorId;
            sensorReading.SensorSetpoint = 1;
            sensorReading.SensorValue = 1.1f;
            sensorReading.Timestamp = new DateTime(2025, 2, 1, 0, 0, 0);
            _testDbContext.Readings.Add(sensorReading);
            _testDbContext.SaveChanges();
            
            SensorReading sensorReading1 = new SensorReading();
            sensorReading1.SensorId = sensorReading.SensorId;
            sensorReading1.SensorSetpoint = 1;
            sensorReading1.SensorValue = 1.2f;
            sensorReading1.Timestamp = new DateTime(2025, 2, 1, 1, 0, 0);
            _testDbContext.Readings.Add(sensorReading1);
            _testDbContext.SaveChanges();
            
            SensorReading sensorReading2 = new SensorReading();
            sensorReading2.SensorId = sensorReading.SensorId;
            sensorReading2.SensorSetpoint = 1;
            sensorReading2.SensorValue = 1.0f;
            sensorReading2.Timestamp = new DateTime(2025, 2, 1, 2, 0, 0);
            _testDbContext.Readings.Add(sensorReading2);
            _testDbContext.SaveChanges();
            
            SensorReading sensorReading3 = new SensorReading();
            sensorReading3.SensorId = sensorReading.SensorId;
            sensorReading3.SensorSetpoint = 1;
            sensorReading3.SensorValue = 1.4f;
            sensorReading3.Timestamp = new DateTime(2025, 2, 1, 4, 0, 0);
            _testDbContext.Readings.Add(sensorReading3);
            _testDbContext.SaveChanges();
            
            SensorReading sensorReading4 = new SensorReading();
            sensorReading4.SensorId = sensorReading.SensorId;
            sensorReading4.SensorSetpoint = 1;
            sensorReading4.SensorValue = 1.2f;
            sensorReading4.Timestamp = new DateTime(2025, 2, 1,7, 0, 0);
            _testDbContext.Readings.Add(sensorReading4);
            _testDbContext.SaveChanges();
            
            SensorReading sensorReading5 = new SensorReading();
            sensorReading5.SensorId = sensorReading.SensorId;
            sensorReading5.SensorSetpoint = 1;
            sensorReading5.SensorValue = 1.2f;
            sensorReading5.Timestamp = new DateTime(2025, 2, 1,11, 0, 0);
            _testDbContext.Readings.Add(sensorReading5);
            
            _testDbContext.SaveChanges();
            seeded = true;
        }
    }

}
