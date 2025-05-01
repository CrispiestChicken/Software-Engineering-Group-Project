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

            MaintenanceRecord = _context.Maintenance.Find(maintenance.MaintenanceId);
            AllSensors = _context.Sensors.ToList();
            AllAccounts = _context.Users.ToList();

            SelectedAccount = AllAccounts.FirstOrDefault(x => x.Email == maintenance.UserEmail);
            SelectedSensor = AllSensors.FirstOrDefault(x => x.SensorId == maintenance.SensorId);
        }

        [RelayCommand]
        private async Task Update()
        {
            // Setting the inputs to the database record.
            MaintenanceRecord.UserEmail = SelectedAccount.Email;
            MaintenanceRecord.SensorId = SelectedSensor.SensorId;


            string result = ValidateData();

            if (result != "Success")
            {
                ErrorMessage = result;
                return;
            }

            Debug.WriteLine(MaintenanceRecord.Date);

            // Saves the changes made in the input boxes to the database.
            await _context.SaveChangesAsync();

            await App.Current.MainPage.Navigation.PopAsync();


        }


        private string ValidateData()
        {
            if(MaintenanceRecord.UserEmail is null or "") return "ERROR: Please Select a Maintainer";

            if (MaintenanceRecord.SensorId == 0) return "ERROR: Please Select a Sensor";

            if (MaintenanceRecord.Comments is null or "") return "ERROR: Please Enter Comments";

            return "Success";
        }

    }
}
