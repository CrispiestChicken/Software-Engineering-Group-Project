using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using SftEngGP.Views;
using SftEngGP.Database.Models;
using SftEngGP.Database.Data;

namespace SftEngGP.ViewModels
{
    internal partial class MaintenanceCreationViewModel : ObservableObject
    {

        private GpDbContext _context;
        public List<Sensor> AllSensors { get; set; }
        public List<User> AllAccounts { get; set; }
        public Maintenance MaintenanceRecord { get; set; }


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
            


        }


        private string ValidateData()
        {
            

            return "Success";
        }

    }
}
