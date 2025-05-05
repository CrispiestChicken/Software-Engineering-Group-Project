using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using SftEngGP.Views;
using SftEngGP.Database.Data;
using SftEngGP.Database.Models;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace SftEngGP.ViewModels;

/// <summary>
/// ViewModel for the AccountEditPage.
/// </summary>
internal partial class AccountEditViewModel : ObservableObject
{

    /// <summary>
    /// The account that is being edited.
    /// </summary>
    public User Account { get; set; }

    /// <summary>
    /// The database context used to access the database.
    /// </summary>
    private GpDbContext _context;
    private TestGPDbContext _testContext;


    /// <summary>
    /// Constructor for the AccountEditViewModel that initializes the account to be edited.
    /// </summary>
    /// <param name="context"></param>
    /// <param name="account"></param>
    public AccountEditViewModel(GpDbContext context, User account)
    {
        _context = context;

        // Get the database-attached entity

       Account = _context.Users.Find(account.UserId);

        if (Account is null)
        {
            // This is for testing.
            Account = new User
            {
                UserId = 9999999,
                Email = "2f3ewf34t354tgff@gferfefew.werfwfwerf.com",
                FName = "Test",
                LName = "Test",
                Address = "Test",
                Password = "Test",
                RoleId = 2
            };
        }


    }

    /// <summary>
    /// A bool that is used to enable or disable editing of the email field.
    /// </summary>
    [ObservableProperty]
    public bool creatingAccount = false;

    /// <summary>
    /// The text that is displayed on the button.
    /// </summary>
    [ObservableProperty]
    public string createOrUpdate = "Update";


    /// <summary>
    /// The error message that is displayed.
    /// </summary>
    [ObservableProperty]
    public string errorMessage = "";


    /// <summary>
    /// Saves a user account to the database if valid.
    /// </summary>
    /// <returns></returns>
    [RelayCommand]
    public async Task Update()
    {

        string result = ValidateData();

        if (result != "Success")
        {
            ErrorMessage = result;
            return;
        }

        // Hashing password for security.
        Account.Password = BCrypt.Net.BCrypt.HashPassword(Account.Password);

        // Saves the changes made in the input boxes to the database and returns to the previous page.
        await _context.SaveChangesAsync();
        try
        {
            await App.Current.MainPage.Navigation.PopAsync();
        }
        catch
        {
            return;
        }

    }


    /// <summary>
    /// Validates the data in the Account object.
    /// </summary>
    /// <returns></returns>
    private string ValidateData()
    {
        if (Account.Password is null or "") return "ERROR:Please Insert a Password";

        if (Account.Password.Length < 8) return "ERROR:Password Must Be Atleast 8 Characters Long";

        if (Account.FName is null or "") return "ERROR:Please Insert a First Name";

        if (Account.LName is null or "") return "ERROR:Please Insert a Surname";

        if (Account.Address is null or "") return "ERROR:Please Insert an Address";

        if (Account.RoleId == 0) return "ERROR:Please Select a Role";

        return "Success";
    }

}