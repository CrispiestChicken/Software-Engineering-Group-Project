using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using SftEngGP.Views;
using SftEngGP.Database.Data;
using SftEngGP.Database.Models;
using System.Collections.ObjectModel;
namespace SftEngGP.ViewModels
{
    /// <summary>
    /// ViewModel for the Maintenance Overview page.
    /// </summary>
    internal partial class MaintenanceOverviewViewModel : ObservableObject
    {
        /// <summary>
        /// Collection of all maintenance records.
        /// </summary>
        public ObservableCollection<Maintenance> AllMaintenance { get; set; }

        /// <summary>
        /// Database context for accessing maintenance records.
        /// </summary>
        private GpDbContext _context;


        // Here so that the XAML can bind to them.
        public int MaintenanceId { get; set; }
        public string UserEmail { get; set; }
        public DateTime Date { get; set; }


        /// <summary>
        /// Constructor for the MaintenanceOverviewViewModel.
        /// </summary>
        public MaintenanceOverviewViewModel()
        {
            _context = new GpDbContext();
            AllMaintenance = new ObservableCollection<Maintenance>(_context.Maintenance.ToList());
        }


        /// <summary>
        /// Command to navigate to the MaintenanceEditPage passing the selected maintenance record.
        /// </summary>
        /// <param name="maintenanceRecord"></param>
        /// <returns></returns>
        [RelayCommand]
        private async Task EditMaintenanceButtonClicked(Maintenance maintenanceRecord) =>
            await App.Current.MainPage.Navigation.PushAsync(new MaintenanceEditPage(maintenanceRecord));


        /// <summary>
        /// Command to navigate to the MaintenanceCreationPage.
        /// </summary>
        /// <returns></returns>
        [RelayCommand]
        private async Task NewMaintenanceButtonClicked() =>
            await App.Current.MainPage.Navigation.PushAsync(new MaintenanceCreationPage());
    }
}
