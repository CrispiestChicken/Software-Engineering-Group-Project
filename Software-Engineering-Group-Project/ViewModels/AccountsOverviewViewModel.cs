using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using SftEngGP.Views;
using SftEngGP.Database.Data;
using System.Collections.ObjectModel;
using SftEngGP.Database.Models;

namespace SftEngGP.ViewModels;


/// <summary>
/// ViewModel for the AccountsOverviewPage.
/// </summary>
internal partial class AccountsOverviewViewModel : ObservableObject
{

    /// <summary>
    /// Collection of all accounts in the database.
    /// </summary>
    public ObservableCollection<User> AllAccounts { get; set; }

    /// <summary>
    /// Database context for accessing the database.
    /// </summary>

    private GpDbContext _context;



    // These have to be here for the XAML to bind to them or it throws an error.
    public string Email { get; set; }
    public string FName { get; set; }
    public int RoleId { get; set; }


    /// <summary>
    /// Constructor for the AccountsOverviewViewModel that gets all accounts from the database.
    /// </summary>
    public AccountsOverviewViewModel()
    {
        _context = new GpDbContext();
        AllAccounts = new ObservableCollection<User>(_context.Users.ToList());
    }


    /// <summary>
    /// Command to navigate the user to the account edit page for the selected account.
    /// </summary>
    /// <param name="account"></param>
    /// <returns></returns>
    [RelayCommand]
    private static async Task EditAccountButtonClicked(User account) =>
        await App.Current.MainPage.Navigation.PushAsync(new AccountEditPage(account));

    /// <summary>
    /// Command to navigate the user to the account creation page.
    /// </summary>
    /// <returns></returns>
    [RelayCommand]
    private static async Task NewAccountButtonClicked() =>
        await App.Current.MainPage.Navigation.PushAsync(new AccountCreationPage());
}