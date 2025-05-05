using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using SftEngGP.Views;
using SftEngGP.Database.Data;
using SftEngGP.Database.Models;
using System.Diagnostics;

namespace SftEngGP.ViewModels
{
    /// <summary>
    /// ViewModel for the Maintenance Edit page.
    /// </summary>
    public partial class MaintenanceEditViewModel : ObservableObject
    {

        /// <summary>
        /// The database context used to access the database.
        /// </summary>
        private GpDbContext _context;

        /// <summary>
        /// List of all sensors in the database.
        /// </summary>
        public List<Sensor> AllSensors { get; set; }

        /// <summary>
        /// List of all users in the database.
        /// </summary>
        public List<User> AllAccounts { get; set; }

        /// <summary>
        /// The maintenance record being edited.
        /// </summary>
        public Maintenance MaintenanceRecord { get; set; }

        /// <summary>
        /// The account assigned the maintenance.
        /// </summary>
        public User SelectedAccount { get; set; }

        /// <summary>
        /// The sensor that needs maintenance.
        /// </summary>
        public Sensor SelectedSensor { get; set; }


        /// <summary>
        /// Sets the button to say Update.
        /// </summary>
        [ObservableProperty]
        public string createOrUpdate = "Update";

        /// <summary>
        /// The error message to be displayed.
        /// </summary>
        [ObservableProperty]
        public string errorMessage = "";


        /// <summary>
        /// Constructor for the MaintenanceEditViewModel.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="maintenance"></param>
        public MaintenanceEditViewModel(GpDbContext context, Maintenance maintenance)
        {
            _context = context;

            // Uses find to get the maintenance object thats tied to the database.
            MaintenanceRecord = _context.Maintenance.Find(maintenance.MaintenanceId);
            AllSensors = _context.Sensors.ToList();
            AllAccounts = _context.Users.ToList();

            // Sets the selected account and sensor to the ones tied to the maintenance object to display to user.
            SelectedAccount = AllAccounts.FirstOrDefault(x => x.Email == maintenance.UserEmail);
            SelectedSensor = AllSensors.FirstOrDefault(x => x.SensorId == maintenance.SensorId);
        }


        /// <summary>
        /// Command to update the maintenance record in the database.
        /// </summary>
        /// <returns></returns>
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

            // Saves the changes made in the input boxes to the database.
            await _context.SaveChangesAsync();

            try
            {
                await App.Current.MainPage.Navigation.PopAsync();
            }
            catch
            {
                return;
            }


        }


        /// <summary>
        /// Validates the data entered by the user.
        /// </summary>
        /// <returns></returns>
        private string ValidateData()
        {
            if(MaintenanceRecord.UserEmail is null or "") return "ERROR: Please Select a Maintainer";

            if (MaintenanceRecord.SensorId == 0) return "ERROR: Please Select a Sensor";

            if (MaintenanceRecord.Comments is null or "") return "ERROR: Please Enter Comments";

            return "Success";
        }

    }
}
