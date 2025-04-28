using System.Collections.ObjectModel;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using SftEngGP.Database.Data;
using SftEngGP.Database.Models;
using SftEngGP.Views;

namespace SftEngGP.ViewModels;

/// <summary>
/// Holds an observable collection of all Sensor view models for all the sensors
/// </summary>
public class AllSensorsViewModel
{
    public ObservableCollection<SensorViewModel> AllSensors { get; set; }

    private GenericGPDbContext _context;
    
    public ICommand SelectSensorCommand { get; }


    public AllSensorsViewModel(GenericGPDbContext context)
    {
        _context = context;
        AllSensors = new ObservableCollection<SensorViewModel>(_context.Sensors.ToList().Select(s => new SensorViewModel(_context, s)));
        SelectSensorCommand = new AsyncRelayCommand<SensorViewModel>(SelectSensorAsync);
    }

    internal async Task SelectSensorAsync(SensorViewModel sensor)
    {
        if (sensor != null)
        {
            await App.Current.MainPage.Navigation.PushAsync(new SensorPage(sensor));
        }
    }
    
}