using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using SftEngGP.Views;

namespace SftEngGP.ViewModels;

internal partial class AccountsOverviewViewModel : ObservableObject
{
    [RelayCommand]
    private async void IndividualAccountButtonClicked() =>
        await App.Current.MainPage.Navigation.PushAsync(new IndividualAccountPage());

    [RelayCommand]
    private async void NewAccountButtonClicked() =>
    await App.Current.MainPage.Navigation.PushAsync(new AccountCreationPage());
}