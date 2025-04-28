using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using SftEngGP.Views;
using SftEngGP.Database.Data;
using SftEngGP.Database.Models;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace SftEngGP.ViewModels;

internal partial class AccountEditViewModel : ObservableObject
{
    public User Account { get; set; }
    private GpDbContext _context;




    // These are specified here so the app builds before data is given to them.
    public int UserId { get; set; }
    public string FName { get; set; }
    public string LName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public int RoleId { get; set; }


    public AccountEditViewModel(User account)
    {
        _context = new GpDbContext();
        Account = _context.Users.Find(account.UserId);
    }


    [ObservableProperty]
    public bool creatingAccount = false;

    [ObservableProperty]
    public string createOrUpdate = "Update";

    [ObservableProperty]
    public string errorMessage = "";


    [RelayCommand]
    public async Task Update()
    {

        string result = ValidateData();

        if (result != "Success")
        {
            ErrorMessage = result;
            return;
        }

        // Saves the changes made in the input boxes to the database.
        await _context.SaveChangesAsync();

        await App.Current.MainPage.Navigation.PopAsync();

    }


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