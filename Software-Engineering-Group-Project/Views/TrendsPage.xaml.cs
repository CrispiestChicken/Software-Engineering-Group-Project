using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SftEngGP.Database.Models;
using SftEngGP.ViewModels;
using Microsoft.Maui.Graphics;
using Syncfusion.Maui.Charts;




namespace SftEngGP.Views
{
    /// <summary>
    /// Displays a line graph for every reading of a selected sensor that contains the reading values
    /// for the Y axis and the timestamp of the readings for the X axis
    /// Using Syncfusions maui chart library
    /// </summary>
    public partial class TrendsPage : ContentView
    {
    
        /// <summary>
        /// Recieves the sensor readings from the sensor view model
        /// and uses it to create a trend graph using
        /// syncfusions maui chart library
        /// </summary>
        /// <param name="viewModel">The sensor view model of the sensor producing the readings</param>
        public TrendsPage(SensorViewModel viewModel)
        {
            //  initialize a chart from the sync fusion maui chart library 
            SfCartesianChart chart = new SfCartesianChart();
            chart.BindingContext = viewModel;
        
            //  initialize the X axis of the graph as a date time axis and add it to the graph
            DateTimeAxis primaryAxis = new DateTimeAxis();
            chart.XAxes.Add(primaryAxis);

            //  initialize the Y axis as a numeric axis and add it to the graph
            NumericalAxis secondaryAxis = new NumericalAxis();
            chart.YAxes.Add(secondaryAxis);
        
        
            // this is indicates that the property from the view model that is used to create the graph is the SensorReadings proptery
            var binding = new Binding() { Path = "SensorReadings" };
            
            // The line series used by the chart
            LineSeries lineSeries = new LineSeries()
            {
                XBindingPath = "Timestamp",
                YBindingPath = "SensorValue",
                Fill = new SolidColorBrush(Color.FromArgb("#314A6E")),
            };
            
            // assign the binding context to the line series
            lineSeries.SetBinding(ChartSeries.ItemsSourceProperty, binding);
            chart.Series.Add(lineSeries);
            
            // create a new maui grid opten that the chart will be added to
            var grid = new Grid() 
            { 
                HorizontalOptions = LayoutOptions.Fill,
                VerticalOptions = LayoutOptions.Fill,
                Padding = new Microsoft.Maui.Thickness(20),
            };
        
            //  add the chart to the new grid
            grid.Children.Add(chart);

            //  add the grid to the page
            this.Content = grid;
        }

    }
}