using Microsoft.EntityFrameworkCore;
using SftEngGP.Database.Data;
using SftEngGP.Database.Models;
using SftEngGP.ViewModels;
using SftEngGP.Models;

namespace SftEngGP.Test
{
    public class MaintenanceEditViewModelTests
    {
        private MaintenanceEditViewModel _viewModel;
        public MaintenanceEditViewModelTests()
        {
            var options = new DbContextOptionsBuilder<GpDbContext>()
            .UseInMemoryDatabase("testgpdb")
            .Options;
            var context = new GpDbContext(options);

            var maintenanceRecord = new Maintenance
            {
                UserEmail = "email@email.com",
                SensorId = 1,
                Date = DateTime.Now,
                Comments = "Test"
            };

            context.Maintenance.Add(maintenanceRecord);
            context.SaveChanges();

            _viewModel = new MaintenanceEditViewModel(context, maintenanceRecord);
        }

        [Fact]
        public void UpdateNormalData()
        {
            var sensor = new Sensor();
            sensor.SensorId = 1;
            _viewModel.SelectedSensor = sensor;

            var user = new User();
            user.Email = "email@email.com";
            _viewModel.SelectedAccount = user;

            _viewModel.MaintenanceRecord.Date = DateTime.Now;
            _viewModel.MaintenanceRecord.Comments = "Test";

            _viewModel.UpdateCommand.Execute(null);

            // Blank because there is no error.
            Assert.Empty(_viewModel.ErrorMessage);
        }

        [Fact]
        public void TestUpdateNoSensorSelected()
        {
            var sensor = new Sensor();
            sensor.SensorId = 0;
            _viewModel.SelectedSensor = sensor;

            var user = new User();
            user.Email = "email@email.com";
            _viewModel.SelectedAccount = user;

            _viewModel.MaintenanceRecord.Comments = "Test";
            _viewModel.MaintenanceRecord.Date = new DateTime(2200, 10, 3);


            _viewModel.UpdateCommand.Execute(null);

            Assert.Equal("ERROR: Please Select a Sensor", _viewModel.ErrorMessage);
        }

        [Fact]
        public void TestUpdateNoEmailSelected()
        {
            var sensor = new Sensor();
            sensor.SensorId = 0;
            _viewModel.SelectedSensor = sensor;

            var user = new User();
            user.Email = "";
            _viewModel.SelectedAccount = user;

            _viewModel.MaintenanceRecord.Comments = "Test";
            _viewModel.MaintenanceRecord.Date = new DateTime(2200, 10, 3);


            _viewModel.UpdateCommand.Execute(null);

            Assert.Equal("ERROR: Please Select a Maintainer", _viewModel.ErrorMessage);
        }

        [Fact]
        public void TestUpdateNoComments()
        {
            var sensor = new Sensor();
            sensor.SensorId = 1;
            _viewModel.SelectedSensor = sensor;

            var user = new User();
            user.Email = "email@email.com";
            _viewModel.SelectedAccount = user;

            _viewModel.MaintenanceRecord.Comments = "";
            _viewModel.MaintenanceRecord.Date = new DateTime(2200, 10, 3);


            _viewModel.UpdateCommand.Execute(null);

            Assert.Equal("ERROR: Please Enter Comments", _viewModel.ErrorMessage);
        }
    }
}
