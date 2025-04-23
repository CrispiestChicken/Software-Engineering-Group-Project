using System;
using SftEngGP.ViewModels;

namespace SftEngGP.Views;

public partial class SensorPage : ContentPage
{
    
    public SensorPage(SensorViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
        Trends.Content = new TrendsPage(viewModel);
        viewModel.GetMissingReadingCount();

    }
}