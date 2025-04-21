using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using SftEngGP.Views;

namespace SftEngGP.ViewModels;

internal partial class AccountCreationViewModel : ObservableObject
{
    [ObservableProperty]
    public bool creatingAccount = true;

    [ObservableProperty]
    public string createOrUpdate = "Create";
}