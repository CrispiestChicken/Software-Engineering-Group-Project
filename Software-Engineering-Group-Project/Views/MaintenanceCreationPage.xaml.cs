using SftEngGP.ViewModels;

namespace SftEngGP.Views;

public partial class MaintenanceCreationPage : ContentPage
{
	public MaintenanceCreationPage(MaintenanceCreationViewModel viewModel)
	{
		this.BindingContext = viewModel;
		InitializeComponent();
	}
}