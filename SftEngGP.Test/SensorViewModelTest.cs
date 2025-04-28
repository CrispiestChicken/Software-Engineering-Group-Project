using SftEngGP.Database.Models;
using SftEngGP.ViewModels;

namespace SftEngGP.Test;


public class SensorViewModelTest: IClassFixture<DatabaseFixture>
{
        DatabaseFixture _fixture;
        private SensorViewModel _viewModel;
        private Sensor _sensor;

        public SensorViewModelTest(DatabaseFixture fixture)
        {
            _fixture = fixture;
            _fixture.Seed();
            _sensor = _fixture._testDbContext.Sensors.First();
            _viewModel = new SensorViewModel(_fixture._testDbContext, _sensor);
        }

        [Fact]
        public void GetMissingReadings_Returns6TimeStamps()
        {
            List<DateTime> missingReadings = _viewModel.GetMissingReadings();
            Assert.Equal(6, _viewModel.MissingReadings.Count);
            
        }

        [Fact]
        public void MissingReadingCount_Returns6()
        {
            Assert.Equal(6, _viewModel.MissingReadingCount);
        }

        [Fact]
        public void GetAllReadingsForSensor_ShouldReturnNotNulll()
        {
            Assert.NotNull(_viewModel.SensorReadings);
        }
}