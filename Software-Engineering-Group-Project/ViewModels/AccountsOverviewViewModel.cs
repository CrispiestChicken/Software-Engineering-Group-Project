using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using SftEngGP.Views;
using SftEngGP.Database.Data;
using System.Collections.ObjectModel;
using SftEngGP.Database.Models;
using System.Diagnostics;

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
    
    public System.Timers.Timer UpdateTimer { get; set; }

    public int UserId { get; set; }
    public int RoleId { get; set; }
    public string FName { get; set; }
    
    /// <summary>
    /// Constructor for the AccountsOverviewViewModel that gets all accounts from the database.
    /// </summary>
    public AccountsOverviewViewModel(GpDbContext context)
    {
        _context = context;
        AllAccounts = new ObservableCollection<User>(_context.Users.ToList());

        // Setting up the timer to update the view every X seconds.
        UpdateTimer = new System.Timers.Timer(10000);
        UpdateTimer.Elapsed += async (sender, e) => await UpdateAccounts();
        UpdateTimer.Start();
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


    private async Task UpdateAccounts()
    {
        ObservableCollection<User> newAccounts = _context.Users.ToObservableCollection();

        if(newAccounts.Count == AllAccounts.Count)
        {
            return;
        }

        // Gets all accounts from the database and updates the view.
        AllAccounts.Clear();
        foreach(User Account in _context.Users)
        {
            AllAccounts.Add(Account);
        }
    }
}