using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using SftEngGP.Views;
using SftEngGP.Models;
using SftEngGP.Database.Data;
using SftEngGP.Database.Models;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using BCrypt.Net;
using System.Diagnostics;

namespace SftEngGP.ViewModels
{
    internal partial class LoginViewModel : ObservableObject
    {
        private GpDbContext _context;
        public User Account { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }


        [ObservableProperty]
        public string errorMessage = "";

        public LoginViewModel()
        {
            _context = new GpDbContext();
        }

        [RelayCommand]
        private async Task Login()
        {
            string result = validateDetails();

            if (result != "Success")
            {
                ErrorMessage = result;
                return;
            }

            LoggedInUser.GetInstance().Login(Account.Email, Account.RoleId);
            Debug.WriteLine(Account.RoleId);


            // Admin shell has the admin pages the main does not.
            if(Account.RoleId == 1)
            {
                App.Current.MainPage = new AdminAppShell();
            }
            else
            {
                App.Current.MainPage = new MainUserShell();
            }

        }


        private string validateDetails()
        {
            // Checking email is valid.
            if(Email is null or "") return "ERROR:Please Insert an Email";


            // Regex from https://regex101.com/r/nen2SZ/1
            string emailRegex = "^[a-zA-Z0-9]+(?:\\.[a-zA-Z0-9]+)*@[a-zA-Z0-9]+(?:\\.[a-zA-Z0-9]+)*$";
            if (Regex.IsMatch(Email, emailRegex) == false) return "ERROR:Please Enter a Valid Email";


            // Checking if email exists in the database.
            Account = _context.Users.FirstOrDefault(x => x.Email == Email);
            if (Account == null) return "ERROR:Email or Password Incorrect";
            Debug.WriteLine(Account.Email);
            




            // Checking password is valid.
            if (Password is null or "") return "ERROR:Please Insert a Password";

            if (BCrypt.Net.BCrypt.EnhancedVerify(Password, Account.Password) == false)
            {
                return "ERROR:Email or Password Incorrect";
            }

            // If all passes then return success.
            return "Success";
        }


    }
}
