using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using SftEngGP.Database.Data;
using SftEngGP.Database.Models;

namespace SftEngGP.ViewModels
{
    /// <summary>
    /// contains all the properties of a sensor, from both the sensor model object and also it's corrosponding measurand model object
    /// Additionally contains a list of all readings produced from it as well related methods
    /// </summary>
    public class SensorViewModel
    {
        private GenericGPDbContext _context;
        private Sensor _sensor;
        private Measurand _measurand;
    
        public int SensorId => _sensor.SensorId;
        public float Latitude => _sensor.Latitude;
        public float Longitude => _sensor.Longitude;
        public string SensorType => _sensor.SensorType;
        public int MeasurandId => _measurand.MeasurandId;
        public string QuantityType => _measurand.QuantityType;
        public string Quantity => _measurand.Quantity;
        public string Symbol => _measurand.Symbol;
        public string Unit => _measurand.Unit;
        public string Frequency => _measurand.Frequency;

        private FrequencyOffset _frequencyOffset;
        public ObservableCollection<SensorReading> SensorReadings { get; set; }

        public List<DateTime> MissingReadings => GetMissingReadings();

        public int MissingReadingCount => GetMissingReadings().Count();

        public SensorViewModel(GenericGPDbContext gpDbContext)
        {
            _context = gpDbContext;
            _sensor = new Sensor();
            _measurand = new Measurand();
            _frequencyOffset = new FrequencyOffset();
            SensorReadings = new ObservableCollection<SensorReading>();
        }
    
        
        public SensorViewModel(GenericGPDbContext gpDbContext, Sensor sensor)
        {
            _context = gpDbContext;
            _sensor = sensor;
            try
            {
                _measurand = _context.Measurands.Single(m => m.SensorId == _sensor.SensorId);
            }
            catch
            {
                _measurand = new Measurand();
                _measurand.QuantityType = "Sensor ID: " + _sensor.SensorId;
            }

            try
            {
                _frequencyOffset = _context.FrequencyOffsets.Single(f => f.Frequency == _measurand.Frequency);
            }
            catch (Exception e)
            {
                _frequencyOffset = new FrequencyOffset();
                // Place holder if the table is empty
                _frequencyOffset.Frequency = "Hourly";
                _frequencyOffset.TimeDifference = new TimeSpan(0, 0, 0);
                _frequencyOffset.DateDifference = 0;
            }
            SensorReadings = new ObservableCollection<SensorReading>(_context.Readings.Where(r => r.SensorId == _sensor.SensorId));
        }

        /// <summary>
        /// Verifies the accuracy of the collected data by retrieving a list of missing readings produced by the sensor
        /// </summary>
        /// <returns>The count of missing readings of the sensor</returns>
        public List<DateTime> GetMissingReadings()
        {
            List<SensorReading> readings = SensorReadings.OrderBy(r => r.Timestamp).ToList();
        
            List<DateTime> missedReadings =  new List<DateTime>();

            if (readings.Count > 0)
            {
                TimeSpan timeSpan = new TimeSpan
                (
                    _frequencyOffset.DateDifference, 
                    _frequencyOffset.TimeDifference.Hours, 
                    _frequencyOffset.TimeDifference.Minutes,
                    _frequencyOffset.TimeDifference.Seconds
                );
        
                DateTimeOffset dateTimeOffset;

                DateTime timestamp = SensorReadings.First().Timestamp;
        
                foreach (SensorReading sensorReading in SensorReadings)
                {
                    while (sensorReading.Timestamp > timestamp)
                    {
                        missedReadings.Add(timestamp);
                        timestamp = timestamp.Add(timeSpan);
                    }
            
                    timestamp = timestamp.Add(timeSpan);
                }
            }
        
            return missedReadings;
        }
    }
}