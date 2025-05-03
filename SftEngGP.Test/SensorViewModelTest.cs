using SftEngGP.Database.Models;
using SftEngGP.ViewModels;

namespace SftEngGP.Test;


public class SensorViewModelTest
{
        DatabaseFixture _fixture;
        private SensorViewModel _daily;
        private SensorViewModel _hourly;

        public SensorViewModelTest()
        {
            _fixture = new DatabaseFixture();
            _daily = new SensorViewModel(_fixture._testDbContext, _fixture.DailySensor.Entity);
            _hourly = new SensorViewModel(_fixture._testDbContext, _fixture.HourlySensor.Entity);
        }

        [Fact]
        public void GetMissingReadingsForHourlySensor_Returns6TimeStamps()
        {
            List<DateTime> missingReadings = _hourly.GetMissingReadings();
            Assert.Equal(6, _hourly.MissingReadings.Count);
            
        }
        
        [Fact]
        public void GetMissingReadingsForDailySensor_Returns3TimeStamps()
        {
            List<DateTime> missingReadings = _daily.GetMissingReadings();
            Assert.Equal(3, _daily.MissingReadings.Count);
            
        }

        [Fact]
        public void MissingReadingCountForHourlySensor_Returns6()
        {
            Assert.Equal(6, _hourly.MissingReadingCount);
        }
        
        [Fact]
        public void MissingReadingCountForDailySensor_Returns3()
        {
            Assert.Equal(3, _daily.MissingReadingCount);
        }

        [Fact]
        public void GetAllReadingsForSensor_ShouldReturnNotNulll()
        {
            Assert.NotNull(_hourly.SensorReadings);
        }

}