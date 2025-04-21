using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using SftEngGP.Views;
namespace SftEngGP.ViewModels
{
    internal partial class MaintenanceOverviewViewModel : ObservableObject
    {
        [RelayCommand]
        private async void EditMaintenanceButtonClicked() =>
            await App.Current.MainPage.Navigation.PushAsync(new MaintenanceEditPage());

        [RelayCommand]
        private async void NewMaintenanceButtonClicked() =>
            await App.Current.MainPage.Navigation.PushAsync(new MaintenanceCreationPage());
    }
}
