using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using SftEngGP.Views;
using SftEngGP.Database.Data;
using SftEngGP.Database.Models;
using System.Collections.ObjectModel;
namespace SftEngGP.ViewModels
{
    internal partial class MaintenanceOverviewViewModel : ObservableObject
    {
        public ObservableCollection<Maintenance> AllMaintenance { get; set; }

        private GpDbContext _context;


        public int MaintenanceId { get; set; }
        public string UserEmail { get; set; }
        public DateTime Date { get; set; }


        public MaintenanceOverviewViewModel()
        {
            _context = new GpDbContext();
            AllMaintenance = new ObservableCollection<Maintenance>(_context.Maintenance.ToList());
        }


        [RelayCommand]
        private async Task EditMaintenanceButtonClicked(Maintenance maintenanceRecord) =>
            await App.Current.MainPage.Navigation.PushAsync(new MaintenanceEditPage(maintenanceRecord));

        [RelayCommand]
        private async Task NewMaintenanceButtonClicked() =>
            await App.Current.MainPage.Navigation.PushAsync(new MaintenanceCreationPage());
    }
}
