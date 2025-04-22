using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AndroidX.Lifecycle;
using Java.Util;
using SftEngGP.Database.Models;
using SftEngGP.ViewModels;
using Microsoft.Maui.Graphics;
using Syncfusion.Maui.Charts;




namespace SftEngGP.Views;

public partial class TrendsPage : ContentPage
{
    
    public TrendsPage(TrendsViewModel viewModel)
    {
        SfCartesianChart chart = new SfCartesianChart();
        
        chart.BindingContext = viewModel;
        
        DateTimeAxis primaryAxis = new DateTimeAxis();

        chart.XAxes.Add(primaryAxis);

        NumericalAxis secondaryAxis = new NumericalAxis();
        

        chart.YAxes.Add(secondaryAxis);
        
        
        var binding = new Binding() { Path = "SensorReadings" };
        LineSeries lineSeries = new LineSeries()
        {
            XBindingPath = "Timestamp",
            YBindingPath = "SensorValue",
            Fill = new SolidColorBrush(Color.FromArgb("#314A6E")),
        };
        lineSeries.SetBinding(ChartSeries.ItemsSourceProperty, binding);
        chart.Series.Add(lineSeries);
        var grid = new Grid() 
        { 
            HorizontalOptions = LayoutOptions.Fill,
            VerticalOptions = LayoutOptions.Fill,
            Padding = new Microsoft.Maui.Thickness(20),
        };
        
        
        grid.Children.Add(chart);

        this.Content = grid;
    } 
    
}