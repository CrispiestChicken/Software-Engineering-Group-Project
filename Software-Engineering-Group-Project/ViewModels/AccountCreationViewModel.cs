using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using SftEngGP.Views;
using SftEngGP.Database.Data;
using SftEngGP.Database.Models;
using BCrypt.Net;
using System.Net.Mail;

namespace SftEngGP.ViewModels;

/// <summary>
/// ViewModel for the Account Creation page.
/// </summary>
public partial class AccountCreationViewModel : ObservableObject
{
    /// <summary>
    /// The database context used to interact with the database.
    /// </summary>
    private GpDbContext _context;

    /// <summary>
    /// The user account being created.
    /// </summary>
    public User Account { get; set; }


    /// <summary>
    /// Constructor for the AccountCreationViewModel.
    /// </summary>
    public AccountCreationViewModel(GpDbContext context)
    {
        _context = context;
        Account = new User();
    }


    /// <summary>
    /// A bool that is used to enable or disable editing of the email field.
    /// </summary>
    [ObservableProperty]
    public bool creatingAccount = true;

    /// <summary>
    /// The text that is displayed on the button.
    /// </summary>
    [ObservableProperty]
    public string createOrUpdate = "Create";

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
    private async Task Create()
    {

        string result = ValidateData();

        if (result != "Success")
        {
            ErrorMessage = result;
            return;
        }

        // Hashing password for security.
        Account.Password = BCrypt.Net.BCrypt.HashPassword(Account.Password);

        // Adding to database then returning to the previous page.
        await _context.AddAsync(Account);
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
    /// Validates the data in Account.
    /// </summary>
    /// <returns></returns>
    private string ValidateData()
    {
        if (Account.Email is null or "") return "ERROR:Please Insert an Email";

        // Checking if the email is a valid email.
        // Doing it like this because it is much faster than a regex.
        try
        {
            new MailAddress(Account.Email);
        }
        catch (Exception)
        {
            return "ERROR:Please Enter a Valid Email";
        }

        if (Account.Password is null or "") return "ERROR:Please Insert a Password";

        if (Account.Password.Length < 8) return "ERROR:Password Must Be Atleast 8 Characters Long";

        if (Account.FName is null or "") return "ERROR:Please Insert a First Name";

        if (Account.LName is null or "") return "ERROR:Please Insert a Surname";

        if (Account.Address is null or "") return "ERROR:Please Insert an Address";

        if (Account.RoleId == 0) return "ERROR:Please Select a Role";

        return "Success";
    }
}