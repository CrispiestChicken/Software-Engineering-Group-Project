using Microsoft.Maui.Maps;
using SftEngGP.Models;
using SftEngGP.ViewModels;
using System.Diagnostics;

namespace SftEngGP.Views;

public partial class MapPage : ContentPage
{
	public MapPage()
	{
        this.BindingContext = new MapViewModel();
		InitializeComponent();

    }

    // These have to be here because the view model can't access them.


    /// <summary>
    /// Starts updating the map when the page is navigated to.
    /// </summary>
    protected override void OnAppearing()
    {
        base.OnAppearing();
        // Start the timer when the page appears.
        if (BindingContext is MapViewModel viewModel)
        {
            viewModel.MapUpdateTimer.Start();
        }
    }


    /// <summary>
    /// Stops updating the map when the page is navigated away from.
    /// </summary>
    /// <param name="args"></param>
    protected override void OnNavigatedFrom(NavigatedFromEventArgs args)
    {
        base.OnNavigatedFrom(args);

        // Stop the timer when navigating away from the page.
        if (BindingContext is MapViewModel viewModel)
        {
            viewModel.MapUpdateTimer.Stop();
        }
    }

}