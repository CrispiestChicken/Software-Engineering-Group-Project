using SftEngGP.ViewModels;

namespace SftEngGP.Views;

public partial class MaintenanceCreationPage : ContentPage
{
	public MaintenanceCreationPage()
	{
		this.BindingContext = new MaintenanceCreationViewModel();
		InitializeComponent();
	}
}