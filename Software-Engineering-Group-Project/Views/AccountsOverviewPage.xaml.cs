using SftEngGP.Database.Data;
using SftEngGP.ViewModels;
using System.Diagnostics;

namespace SftEngGP.Views;

public partial class AccountsOverviewPage : ContentPage
{
	public AccountsOverviewPage()
	{
		this.BindingContext = new AccountsOverviewViewModel();
		InitializeComponent();
	}


    // Have to have these here and not in viewmodel because you cant override it from the view model.


    /// <summary>
    /// Starts Updating the page when the page is navigated to.
    /// </summary>
    protected override void OnAppearing()
    {
        base.OnAppearing();
        // Start the timer when the page appears.
        if (BindingContext is AccountsOverviewViewModel viewModel)
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

        // Stop the timer when navigating away from the page.
        if (BindingContext is AccountsOverviewViewModel viewModel)
        {
            viewModel.UpdateTimer.Stop();
        }
    }
}