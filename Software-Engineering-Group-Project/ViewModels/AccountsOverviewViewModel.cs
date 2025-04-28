using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using SftEngGP.Views;
using SftEngGP.Database.Data;
using System.Collections.ObjectModel;
using SftEngGP.Database.Models;
using System.Diagnostics;

namespace SftEngGP.ViewModels;

internal partial class AccountsOverviewViewModel : ObservableObject
{
    public ObservableCollection<User> AllAccounts { get; set; }

    private GpDbContext _context;

    public int UserId { get; set; }
    public string FName { get; set; }
    public int RoleId { get; set; }


    public AccountsOverviewViewModel()
    {
        _context = new GpDbContext();
        AllAccounts = new ObservableCollection<User>(_context.Users.ToList());
    }



    [RelayCommand]
    private static async void EditAccountButtonClicked(int userID) =>
        await App.Current.MainPage.Navigation.PushAsync(new AccountEditPage(userID));

    [RelayCommand]
    private static async void NewAccountButtonClicked() =>
        await App.Current.MainPage.Navigation.PushAsync(new AccountCreationPage());
}