using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using SftEngGP.Views;
using SftEngGP.Database.Data;
using SftEngGP.Database.Models;
using System.Diagnostics;

namespace SftEngGP.ViewModels
{
    internal partial class MaintenanceEditViewModel : ObservableObject
    {
        private GpDbContext _context;
        public List<Sensor> AllSensors { get; set; }
        public List<User> AllAccounts { get; set; }
        public Maintenance MaintenanceRecord { get; set; }
        public User SelectedAccount { get; set; }
        public Sensor SelectedSensor { get; set; }


        [ObservableProperty]
        public string createOrUpdate = "Update";

        [ObservableProperty]
        public string errorMessage = "";


        public MaintenanceEditViewModel(Maintenance maintenance)
        {
            _context = new GpDbContext();

            MaintenanceRecord = maintenance;
            AllSensors = _context.Sensors.ToList();
            AllAccounts = _context.Users.ToList();

            SelectedAccount = AllAccounts.FirstOrDefault(x => x.Email == maintenance.UserEmail);
            SelectedSensor = AllSensors.FirstOrDefault(x => x.SensorId == maintenance.SensorId);
        }

        [RelayCommand]
        private async Task Update()
        {



        }


        private string ValidateData()
        {


            return "Success";
        }

    }
}
