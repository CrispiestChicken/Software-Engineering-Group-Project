using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using SftEngGP.Views;
using SftEngGP.Database.Models;
using SftEngGP.Database.Data;
using System.Diagnostics;

namespace SftEngGP.ViewModels
{
    /// <summary>
    /// ViewModel for the Maintenance Creation page.
    /// </summary>
    public partial class MaintenanceCreationViewModel : ObservableObject
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
        /// The maintenance record being created.
        /// </summary>
        public Maintenance MaintenanceRecord { get; set; }

        /// <summary>
        /// The selected account assigned the maintenance.
        /// </summary>
        public User SelectedAccount { get; set; }

        /// <summary>
        /// The sensor that needs maintenance.
        /// </summary>
        public Sensor SelectedSensor { get; set; }


        /// <summary>
        /// Sets the button to say Create.
        /// </summary>
        [ObservableProperty]
        public string createOrUpdate = "Create";

        /// <summary>
        /// The error message to be displayed.
        /// </summary>
        [ObservableProperty]
        public string errorMessage = "";


        /// <summary>
        /// Constructor for the MaintenanceCreationViewModel.
        /// </summary>
        public MaintenanceCreationViewModel(GpDbContext context)
        {
            _context = context;

            MaintenanceRecord = new Maintenance();
            AllSensors = _context.Sensors.ToList();
            AllAccounts = _context.Users.ToList();
        }


        /// <summary>
        /// Command to create a new maintenance record.
        /// </summary>
        /// <returns></returns>
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
            if (MaintenanceRecord.UserEmail is null or "") return "ERROR: Please Select a Maintainer";

            if (MaintenanceRecord.SensorId == 0) return "ERROR: Please Select a Sensor";

            if (MaintenanceRecord.Comments is null or "") return "ERROR: Please Enter Comments";


            return "Success";
        }

    }
}
