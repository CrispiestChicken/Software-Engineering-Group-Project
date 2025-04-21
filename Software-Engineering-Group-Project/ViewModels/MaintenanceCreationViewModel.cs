using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using SftEngGP.Views;

namespace SftEngGP.ViewModels
{
    internal partial class MaintenanceCreationViewModel : ObservableObject
    {
        [ObservableProperty]
        public string createOrUpdate = "Create";
    }
}
