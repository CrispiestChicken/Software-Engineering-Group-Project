using SftEngGP.Database.Models;
using SftEngGP.ViewModels;

namespace SftEngGP.Views;

public partial class MaintenanceEditPage : ContentPage
{
	public MaintenanceEditPage(MaintenanceEditViewModel viewModel)
	{
		this.BindingContext = viewModel;
		InitializeComponent();
	}
}