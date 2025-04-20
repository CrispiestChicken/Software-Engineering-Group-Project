using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using SftEngGP.Views;

namespace SftEngGP.ViewModels;

internal partial class AccountEditViewModel : ObservableObject
{
    [ObservableProperty]
    public bool creatingAccount = false;

    [ObservableProperty]
    public string createOrUpdate = "Update";
}