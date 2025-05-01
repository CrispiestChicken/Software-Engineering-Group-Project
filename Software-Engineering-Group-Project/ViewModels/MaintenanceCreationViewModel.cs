using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using SftEngGP.Views;
using SftEngGP.Database.Models;
using SftEngGP.Database.Data;
using System.Diagnostics;

namespace SftEngGP.ViewModels
{
    internal partial class MaintenanceCreationViewModel : ObservableObject
    {

        private GpDbContext _context;
        public List<Sensor> AllSensors { get; set; }
        public List<User> AllAccounts { get; set; }
        public Maintenance MaintenanceRecord { get; set; }
        public User SelectedAccount { get; set; }
        public Sensor SelectedSensor { get; set; }


        [ObservableProperty]
        public string createOrUpdate = "Create";

        [ObservableProperty]
        public string errorMessage = "";


        public MaintenanceCreationViewModel()
        {
            _context = new GpDbContext();

            MaintenanceRecord = new Maintenance();
            AllSensors = _context.Sensors.ToList();
            AllAccounts = _context.Users.ToList();
        }


        [RelayCommand]
        private async Task Create()
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
            Debug.WriteLine(MaintenanceRecord.UserEmail);
            Debug.WriteLine(MaintenanceRecord.SensorId);
            Debug.WriteLine(MaintenanceRecord.Comments);

            // Saves the changes made in the input boxes to the database.
            await _context.Maintenance.AddAsync(MaintenanceRecord);



            try
            {
                await _context.SaveChangesAsync();
            }
            catch(Exception e)
            {
                await App.Current.MainPage.DisplayAlert("Failed To Record Maintenance", e.Message, "Ok");
            }

            await App.Current.MainPage.Navigation.PopAsync();



        }


        private string ValidateData()
        {
            if (MaintenanceRecord.UserEmail is null or "") return "ERROR: Please Select a Maintainer";

            if (MaintenanceRecord.SensorId == 0) return "ERROR: Please Select a Sensor";

            if (MaintenanceRecord.Comments is null or "") return "ERROR: Please Enter Comments";

            return "Success";
        }

    }
}
