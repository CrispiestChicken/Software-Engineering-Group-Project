using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using SftEngGP.Views;
using SftEngGP.Database.Data;

namespace SftEngGP.ViewModels;

/// <summary>
/// ViewModel for the Admin Dashboard.
/// </summary>
internal partial class AdminDashboardViewModel : ObservableObject
{

    /// <summary>
    /// Command to navigate to the Accounts Overview page.
    /// </summary>
    [RelayCommand]
    private async void AccountsButtonClicked() =>
        await App.Current.MainPage.Navigation.PushAsync(new AccountsOverviewPage());

    /// <summary>
    /// Command to navigate to the Sensors Overview page.
    /// </summary>
    [RelayCommand]
    private async void SensorsButtonClicked() =>
        await App.Current.MainPage.Navigation.PushAsync(new SensorsOverviewPage());
}