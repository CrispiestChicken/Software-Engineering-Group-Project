using System;
using SftEngGP.ViewModels;

namespace SftEngGP.Views
{
    /// <summary>
    /// Displays a selected sensor along with a trend graph of readings recorded by sensor as well as information on the accuracy and integrity of the sensor
    /// </summary>
    public partial class SensorPage : ContentPage
    {
        public SensorPage(SensorViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
            Trends.Content = new TrendsPage(viewModel);

        }
    }
}