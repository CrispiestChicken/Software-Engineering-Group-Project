using SftEngGP.ViewModels;
using SftEngGP.Models;
using System.Diagnostics;

namespace SftEngGP.Views;

public partial class MaintenanceOverviewPage : ContentPage
{
	public MaintenanceOverviewPage()
	{
		this.BindingContext = new MaintenanceOverviewViewModel();
		InitializeComponent();
	}
}