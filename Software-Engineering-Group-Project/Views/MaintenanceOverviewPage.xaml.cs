using SftEngGP.ViewModels;

namespace SftEngGP.Views;

public partial class MaintenanceOverviewPage : ContentPage
{
	public MaintenanceOverviewPage()
	{
		this.BindingContext = new MaintenanceOverviewViewModel();
		InitializeComponent();
	}
}