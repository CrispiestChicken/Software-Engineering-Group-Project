using Microsoft.EntityFrameworkCore;
using SftEngGP.Database.Data;
using SftEngGP.Database.Models;
using SftEngGP.ViewModels;
using SftEngGP.Models;

namespace SftEngGP.Test
{
    public class MaintenanceCreationViewModelTests
    {
        private MaintenanceCreationViewModel _viewModel;
        public MaintenanceCreationViewModelTests()
        {
            var options = new DbContextOptionsBuilder<GpDbContext>()
                .UseInMemoryDatabase("testgpdb")
                .Options;
            var context = new GpDbContext(options);
            _viewModel = new MaintenanceCreationViewModel(context);
        }


        [Fact]
        public void MaintenanceCreationViewModelConstructorTest()
        {
            var options = new DbContextOptionsBuilder<GpDbContext>()
                .UseInMemoryDatabase("testgpdb")
                .Options;
            var context = new GpDbContext(options);
            var viewModel = new MaintenanceCreationViewModel(context);
            Assert.NotNull(viewModel);
            Assert.NotNull(viewModel.MaintenanceRecord);
            Assert.Equal("Create", viewModel.CreateOrUpdate);
            Assert.Equal("", viewModel.ErrorMessage);
        }


        [Fact]
        public void TestCreateNormalData()
        {
            var sensor = new Sensor();
            sensor.SensorId = 1;
            _viewModel.SelectedSensor = sensor;

            var user = new User();
            user.Email = "email@email.com";
            _viewModel.SelectedAccount = user;

            _viewModel.MaintenanceRecord.Comments = "Test";
            _viewModel.MaintenanceRecord.Date = new DateTime(2200,10,3);


            _viewModel.CreateCommand.Execute(null);

            // Blank because there is no error.
            Assert.Empty(_viewModel.ErrorMessage);
        }

        [Fact]
        public void TestCreateNoSensorSelected()
        {
            var sensor = new Sensor();
            sensor.SensorId = 0;
            _viewModel.SelectedSensor = sensor;

            var user = new User();
            user.Email = "email@email.com";
            _viewModel.SelectedAccount = user;

            _viewModel.MaintenanceRecord.Comments = "Test";
            _viewModel.MaintenanceRecord.Date = new DateTime(2200, 10, 3);


            _viewModel.CreateCommand.Execute(null);

            Assert.Equal("ERROR: Please Select a Sensor", _viewModel.ErrorMessage);
        }

        [Fact]
        public void TestCreateNoEmailSelected()
        {
            var sensor = new Sensor();
            sensor.SensorId = 0;
            _viewModel.SelectedSensor = sensor;

            var user = new User();
            user.Email = "";
            _viewModel.SelectedAccount = user;

            _viewModel.MaintenanceRecord.Comments = "Test";
            _viewModel.MaintenanceRecord.Date = new DateTime(2200, 10, 3);


            _viewModel.CreateCommand.Execute(null);

            Assert.Equal("ERROR: Please Select a Maintainer", _viewModel.ErrorMessage);
        }

        [Fact]
        public void TestCreateNoComments()
        {
            var sensor = new Sensor();
            sensor.SensorId = 1;
            _viewModel.SelectedSensor = sensor;

            var user = new User();
            user.Email = "email@email.com";
            _viewModel.SelectedAccount = user;

            _viewModel.MaintenanceRecord.Comments = "";
            _viewModel.MaintenanceRecord.Date = new DateTime(2200, 10, 3);


            _viewModel.CreateCommand.Execute(null);

            Assert.Equal("ERROR: Please Enter Comments", _viewModel.ErrorMessage);
        }
    }
}
