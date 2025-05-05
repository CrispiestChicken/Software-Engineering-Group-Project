using SftEngGP.Database.Models;
using SftEngGP.ViewModels;

namespace SftEngGP.Views;

public partial class MaintenanceEditPage : ContentPage
{
	public MaintenanceEditPage(Maintenance maintenanceRecord)
	{
		this.BindingContext = new MaintenanceEditViewModel(maintenanceRecord);
		InitializeComponent();
	}
}