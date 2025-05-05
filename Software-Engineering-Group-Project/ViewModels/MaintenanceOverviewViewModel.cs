using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using SftEngGP.Views;
using SftEngGP.Database.Data;
using SftEngGP.Database.Models;
using System.Collections.ObjectModel;
using CommunityToolkit.Maui.Core.Extensions;
namespace SftEngGP.ViewModels
{
    /// <summary>
    /// ViewModel for the Maintenance Overview page.
    /// </summary>
    public partial class MaintenanceOverviewViewModel : ObservableObject
    {
        /// <summary>
        /// Collection of all maintenance records.
        /// </summary>
        public ObservableCollection<Maintenance> AllMaintenance { get; set; }

        /// <summary>
        /// Database context for accessing maintenance records.
        /// </summary>
        private GpDbContext _context;

        public System.Timers.Timer UpdateTimer { get; set; }


        // Here so that the XAML can bind to them.
        public int MaintenanceId { get; set; }
        public string UserEmail { get; set; }
        public DateTime Date { get; set; }


        /// <summary>
        /// Constructor for the MaintenanceOverviewViewModel.
        /// </summary>
        public MaintenanceOverviewViewModel(GpDbContext context)
        {
            _context = context;
            AllMaintenance = new ObservableCollection<Maintenance>(_context.Maintenance.ToList());


            // Set up a timer to refresh the data every X seconds.
            UpdateTimer = new System.Timers.Timer(10000);
            UpdateTimer.Elapsed += (sender, e) => UpdateMaintenance();
            UpdateTimer.Start();
        }


        /// <summary>
        /// Command to navigate to the MaintenanceEditPage passing the selected maintenance record.
        /// </summary>
        /// <param name="maintenanceRecord"></param>
        /// <returns></returns>
        [RelayCommand]
        private async Task EditMaintenanceButtonClicked(Maintenance maintenanceRecord)
        {
            var viewModel = new MaintenanceEditViewModel(_context, maintenanceRecord);
            var editPage = new MaintenanceEditPage(viewModel);
            await App.Current.MainPage.Navigation.PushAsync(editPage);
        }


        /// <summary>
        /// Command to navigate to the MaintenanceCreationPage.
        /// </summary>
        /// <returns></returns>
        [RelayCommand]
        private async Task NewMaintenanceButtonClicked()
        {
            var context = (GpDbContext)App.Current.Handler.MauiContext.Services.GetService(typeof(GpDbContext));
            var viewModel = new MaintenanceCreationViewModel(context);
            var page = new MaintenanceCreationPage(viewModel);
            await App.Current.MainPage.Navigation.PushAsync(page);
        }
        
        private async Task UpdateMaintenance()
        {
            // Fetch the latest data from the database.
            ObservableCollection<Maintenance> newMaintenance = _context.Maintenance.ToObservableCollection();

            if(newMaintenance.Count == AllMaintenance.Count)
            {
                return;
            }

            // Clear the existing collection and add the updated data.
            AllMaintenance.Clear();
            foreach (var maintenance in newMaintenance)
            {
                AllMaintenance.Add(maintenance);
            }
        }
    }
}
