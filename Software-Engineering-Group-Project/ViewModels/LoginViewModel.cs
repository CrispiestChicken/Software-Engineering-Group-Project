using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using SftEngGP.Views;
using SftEngGP.Models;
using SftEngGP.Database.Data;
using SftEngGP.Database.Models;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Net.Mail;
using BCrypt.Net;
using System.Diagnostics;

namespace SftEngGP.ViewModels
{
    /// <summary>
    /// ViewModel for the Login page.
    /// </summary>
    public partial class LoginViewModel : ObservableObject
    {
        /// <summary>
        /// Database context for accessing the database.
        /// </summary>
        private GpDbContext _context;

        /// <summary>
        /// User object representing the user logging in.
        /// </summary>
        public User Account { get; set; }

        /// <summary>
        /// Email input from the user.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Password input from the user.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Error message to be displayed to the user.
        /// </summary>
        [ObservableProperty]
        public string errorMessage = "";


        /// <summary>
        /// Constructor for the LoginViewModel.
        /// </summary>
        public LoginViewModel(GpDbContext context)
        {
            _context = context;
        }


        /// <summary>
        /// Command to handle the login action.
        /// </summary>
        /// <returns></returns>
        [RelayCommand]
        private async Task Login()
        {
            // Runs the code asynchronously so the app doesn't freeze.
            await Task.Run(() => 
            { 
                string result = validateDetails();

                if (result != "Success")
                {
                    ErrorMessage = result;
                    return;
                }

                // Sets the logged in user.
                LoggedInUser.GetInstance().Login(Account.Email, Account.RoleId);

                // Doing this on main thread because UI changes can't be done on a background thread.
                // Also still inside the asynchronous part so that this doesn't run first and log the user in before validation.
                MainThread.BeginInvokeOnMainThread(() =>
                {
                    // Admin shell has the admin pages the main does not.
                    if (Account.RoleId == 1)
                    {
                        App.Current.MainPage = new AdminAppShell();
                    }
                    else
                    {
                        App.Current.MainPage = new MainUserShell();
                    }
                });

            });
        }


        /// <summary>
        /// Checks the users inputs to see if they match with an account in the database.
        /// </summary>
        /// <returns></returns>
        private string validateDetails()
        {
            // Checking email is valid.
            if(Email is null or "") return "ERROR:Please Insert an Email";

            // Checking if the email is a valid email.
            // Doing it like this because it is much faster than a regex.
            try
            {
                new MailAddress(Email);
            }
            catch(Exception)
            {
                return "ERROR:Please Enter a Valid Email";
            }

            // Checking if email exists in the database.
            Account = _context.Users.FirstOrDefault(x => x.Email == Email);
            if (Account == null) return "ERROR:Email or Password Incorrect";


            // Checking password is valid.
            if (Password is null or "") return "ERROR:Please Insert a Password";


            if (BCrypt.Net.BCrypt.Verify(Password, Account.Password) == false)
            {
                return "ERROR:Email or Password Incorrect";
            }

            // If all passes then return success.
            return "Success";
        }


    }
}
