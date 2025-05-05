using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;
using SftEngGP.Database.Data;
using SftEngGP.Database.Models;

namespace SftEngGP.Test;

public class DatabaseFixture
{
    internal TestGPDbContext? _testDbContext { get; private set; }
    private bool seeded;
    public EntityEntry<Sensor> DailySensor { get; set; }
    public EntityEntry<Sensor> HourlySensor { get; set; }
    
    
    public DatabaseFixture()
    {
        _testDbContext = new TestGPDbContext();
        _testDbContext.Database.EnsureDeleted();
        _testDbContext.Database.EnsureCreated();
        _testDbContext.Database.OpenConnection();
        _testDbContext.Database.Migrate();
        Seed();
    }
    
    internal void Seed()
    {
        if (!seeded)
        {
            AddFrequencyOffset("Hourly", new TimeSpan(1, 0, 0), 0);
            AddFrequencyOffset("Daily", new TimeSpan(0, 0, 0), 1);
            
            HourlySensor = AddSensorWithMeasurand("Air quality", 1.1F, 1.2f, "Hourly", "Nitrogen dioxide",
                "microgrammes per cubic metre", "NO2", "ug/m3").Item1;
            
            DailySensor = AddSensorWithMeasurand("Water quality", 23.5F, 19.2f, "Daily", "Escherichia coli",
                "Colony forming units (cfu) per 100ml", "EC", "cfu/100ml").Item1;
            
            AddSensorWithMeasurand("Air quality", 23.5F, 19.2f, "Hourly", "Sulphur dioxide",
                "Colony forming units (cfu) per 100ml", "SO2", "ug/m3");
            AddSensorWithMeasurand("Air quality", 23.5F, 19.2f, "Hourly", "Particulate matter <= 2.5 microns in diameter",
                "Colony forming units (cfu) per 100ml", "PM2.5", "ug/m3");
            AddSensorWithMeasurand("Air quality", 23.5F, 19.2f, "Hourly", "Particulate matter <= 10 microns in diameter",
                "Colony forming units (cfu) per 100ml", "PM10", "ug/m3");
            
            AddSensorReading(HourlySensor.Entity.SensorId, 1f, 1.1f, new DateTime(2025, 2, 1, 0, 0, 0));
            AddSensorReading(HourlySensor.Entity.SensorId, 1f, 1.2f, new DateTime(2025, 2, 1, 1, 0, 0));
            AddSensorReading(HourlySensor.Entity.SensorId, 1f, 1.0f, new DateTime(2025, 2, 1, 2, 0, 0));
            AddSensorReading(HourlySensor.Entity.SensorId, 1f, 1.4f, new DateTime(2025, 2, 1, 4, 0, 0));
            AddSensorReading(HourlySensor.Entity.SensorId, 1f, 1.2f, new DateTime(2025, 2, 1, 7, 0, 0));
            AddSensorReading(HourlySensor.Entity.SensorId, 1f, 2.3f, new DateTime(2025, 2, 1, 11, 0, 0));
            
            AddSensorReading(DailySensor.Entity.SensorId, 1f, 23.4f, new DateTime(2025, 3, 1, 0, 0, 0));
            AddSensorReading(DailySensor.Entity.SensorId, 1f, 53.2f, new DateTime(2025, 3, 3, 0, 0, 0));
            AddSensorReading(DailySensor.Entity.SensorId, 1f, 21.2f, new DateTime(2025, 3, 5, 0, 0, 0));
            AddSensorReading(DailySensor.Entity.SensorId, 1f, 13.4f, new DateTime(2025, 3, 7, 0, 0, 0));

            AddIncidents(HourlySensor.Entity.SensorId, "Temp", "Test", new DateTime(2025, 5, 5));
            AddIncidents(HourlySensor.Entity.SensorId, "Temp", "Test", new DateTime(2025, 5, 5));
            AddIncidents(HourlySensor.Entity.SensorId, "Temp", "Test", new DateTime(2025, 5, 5));
            AddIncidents(HourlySensor.Entity.SensorId, "Temp", "Test", new DateTime(2025, 5, 5));

            AddIncidents(DailySensor.Entity.SensorId, "Temp", "Test", new DateTime(2025, 5, 5));
            AddIncidents(DailySensor.Entity.SensorId, "Temp", "Test", new DateTime(2025, 5, 5));
            AddIncidents(DailySensor.Entity.SensorId, "Temp", "Test", new DateTime(2025, 5, 5));
            AddIncidents(DailySensor.Entity.SensorId, "Temp", "Test", new DateTime(2025, 5, 5));
            AddIncidents(DailySensor.Entity.SensorId, "Temp", "Test", new DateTime(2025, 5, 5));





            seeded = true;
        }
    }

    private EntityEntry<FrequencyOffset> AddFrequencyOffset(string frequency, TimeSpan timeDifference, int dateDifference)
    {
        FrequencyOffset frequencyOffset = new FrequencyOffset();
        frequencyOffset.Frequency = frequency;
        frequencyOffset.DateDifference = dateDifference;
        frequencyOffset.TimeDifference = timeDifference;
        
        EntityEntry<FrequencyOffset> frequencyOffsetEntity = _testDbContext.Add(frequencyOffset);
        _testDbContext.SaveChanges();
        return frequencyOffsetEntity;
    }

    private EntityEntry<SensorReading> AddSensorReading(int sensorId, float sensorSetpoint, float sensorValue, DateTime timeStamp)
    {
        SensorReading sensorReading = new SensorReading();

        sensorReading.SensorId = sensorId;
        sensorReading.SensorSetpoint = sensorSetpoint;
        sensorReading.SensorValue = sensorValue;
        sensorReading.Timestamp = timeStamp;
        sensorReading.MeasurementType = "type";

        EntityEntry<SensorReading> sensorEntity = _testDbContext.Add(sensorReading);
        _testDbContext.SaveChanges();
        return sensorEntity;
    }

    private Tuple<EntityEntry<Sensor>, EntityEntry<Measurand>> AddSensorWithMeasurand(string sensorType, float latitude, float longitude, string frequency, string quantityType, string quantity, string symbol, string unit)
    {
        Sensor sensor = new Sensor();
        sensor.SensorType = sensorType;
        sensor.Latitude = latitude;
        sensor.Longitude = longitude;
        EntityEntry<Sensor> sensorEntity = _testDbContext.Add(sensor);
        _testDbContext.SaveChanges();
        
        Measurand measurand = new Measurand();
        measurand.Frequency = frequency;
        measurand.SensorId = sensorEntity.Entity.SensorId;
        measurand.QuantityType = quantityType;
        measurand.Quantity = quantity;
        measurand.Symbol = symbol;
        measurand.Unit = unit;
        EntityEntry<Measurand> measurandEntity = _testDbContext.Add(measurand);
        _testDbContext.SaveChanges();
        return new Tuple<EntityEntry<Sensor>, EntityEntry<Measurand>>(sensorEntity, measurandEntity);
    }

    private void AddIncidents(int sensorID, string type, string alert, DateTime eventDate)
    {
        var incident = new Incidence
        {
            SensorId = sensorID,
            IncidenceType = type,
            Alert = alert,
            DateOfEvent = eventDate
        };


        _testDbContext.Add(incident);
        _testDbContext.SaveChanges();
    }

}
