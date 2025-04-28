using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using SftEngGP.Views;
using SftEngGP.Database.Data;

namespace SftEngGP.ViewModels;

internal partial class AdminDashboardViewModel : ObservableObject
{

    [RelayCommand]
    private async void AccountsButtonClicked() =>
        await App.Current.MainPage.Navigation.PushAsync(new AccountsOverviewPage());

    [RelayCommand]
    private async void SensorsButtonClicked() =>
        await App.Current.MainPage.Navigation.PushAsync(new SensorsOverviewPage());
}