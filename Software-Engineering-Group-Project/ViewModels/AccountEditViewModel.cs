using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using SftEngGP.Views;
using SftEngGP.Database.Data;
using SftEngGP.Database.Models;
using System.Collections.ObjectModel;

namespace SftEngGP.ViewModels;

internal partial class AccountEditViewModel : ObservableObject
{
    public User Account { get; set; }
    private GpDbContext _context;
    public int UserId { get; set; }
    public string FName { get; set; }
    public string LName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public int RoleId { get; set; }


    public AccountEditViewModel(User account)
    {
        _context = new GpDbContext();
        Account = account;
    }


    [ObservableProperty]
    public bool creatingAccount = false;

    [ObservableProperty]
    public string createOrUpdate = "Update";
}