using SftEngGP.ViewModels;
using SftEngGP.Models;
using System.Diagnostics;
using SftEngGP.Database.Data;

namespace SftEngGP.Views;

public partial class MaintenanceOverviewPage : ContentPage
{
	public MaintenanceOverviewPage(GpDbContext context)
	{
		this.BindingContext = context;
		InitializeComponent();
	}

    // Have to have these here and not in viewmodel because you cant override it from the view model.

    /// <summary>
    /// Starts Updating the page when the page is navigated to.
    /// </summary>
	protected override void OnAppearing()
    {
        base.OnAppearing();
        // Start the timer when the page appears
        if (BindingContext is MaintenanceOverviewViewModel viewModel)
        {
            viewModel.UpdateTimer.Start();
        }
    }


    /// <summary>
    /// Stops Updating the page when the page is navigated away from.
    /// </summary>
    /// <param name="args"></param>
    protected override void OnNavigatedFrom(NavigatedFromEventArgs args)
    {
        base.OnNavigatedFrom(args);

        // Stop the timer when navigating away from the page
        if (BindingContext is MaintenanceOverviewViewModel viewModel)
        {
            viewModel.UpdateTimer.Stop();
        }
    }


}