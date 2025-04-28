using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using SftEngGP.Views;
using SftEngGP.Database.Data;
using SftEngGP.Database.Models;

namespace SftEngGP.ViewModels;

internal partial class AccountCreationViewModel : ObservableObject
{
    private GpDbContext _context;
    public User Account;





    [ObservableProperty]
    public bool creatingAccount = true;

    [ObservableProperty]
    public string createOrUpdate = "Create";


    [RelayCommand]
    private async Task Create()
    {
        _context.Add(Account);
        _context.SaveChanges();
        await App.Current.MainPage.Navigation.PopAsync();

    }
}