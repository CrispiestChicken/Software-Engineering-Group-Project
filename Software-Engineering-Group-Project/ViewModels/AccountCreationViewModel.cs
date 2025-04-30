using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using SftEngGP.Views;
using SftEngGP.Database.Data;
using SftEngGP.Database.Models;
using System.Text.RegularExpressions;
using BCrypt.Net;

namespace SftEngGP.ViewModels;

internal partial class AccountCreationViewModel : ObservableObject
{
    private GpDbContext _context;
    public User Account { get; set; }


    public AccountCreationViewModel()
    {
        _context = new GpDbContext();
        Account = new User();
    }

    // These are specified here so the app builds before data is given to them.
    public int UserId { get; set; }
    public string FName { get; set; }
    public string LName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public int RoleId { get; set; }



    [ObservableProperty]
    public bool creatingAccount = true;

    [ObservableProperty]
    public string createOrUpdate = "Create";

    [ObservableProperty]
    public string errorMessage = "";


    [RelayCommand]
    private async Task Create()
    {

        string result = ValidateData();

        if (result != "Success")
        {
            ErrorMessage = result;
            return;
        }

        Account.Password = BCrypt.Net.BCrypt.EnhancedHashPassword(Account.Password);

        await _context.AddAsync(Account);
        await _context.SaveChangesAsync();
        await App.Current.MainPage.Navigation.PopAsync();
    }


    private string ValidateData()
    {
        if (Account.Email is null or "") return "ERROR:Please Insert an Email";

        // Regex from https://regex101.com/r/nen2SZ/1
        string emailRegex = "^[a-zA-Z0-9]+(?:\\.[a-zA-Z0-9]+)*@[a-zA-Z0-9]+(?:\\.[a-zA-Z0-9]+)*$";
        if (Regex.IsMatch(Account.Email, emailRegex) == false) return "ERROR:Please Enter a Valid Email";

        if (Account.Password is null or "") return "ERROR:Please Insert a Password";

        if (Account.Password.Length < 8) return "ERROR:Password Must Be Atleast 8 Characters Long";

        if (Account.FName is null or "") return "ERROR:Please Insert a First Name";

        if (Account.LName is null or "") return "ERROR:Please Insert a Surname";

        if (Account.Address is null or "") return "ERROR:Please Insert an Address";

        if (Account.RoleId == 0) return "ERROR:Please Select a Role";

        return "Success";
    }
}