using SftEngGP.ViewModels;

namespace SftEngGP.Views;

public partial class MaintenanceEditPage : ContentPage
{
	public MaintenanceEditPage()
	{
		this.BindingContext = new MaintenanceEditViewModel();
		InitializeComponent();
	}
}