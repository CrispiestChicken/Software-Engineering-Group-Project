using System;
using System.Timers;
using Timer = System.Timers.Timer;


/// <summary>
/// Represents a service for simulating time progression. This class allows managing
/// a simulated DateTime, which can be advanced automatically or manipulated for scenarios
/// like testing, simulation environments, or applications requiring a controllable time source.
/// The simulated time is updated regularly at a fixed interval to mock real-time advancement.
/// </summary>
public class SimulatedTimeService
{
    public event Action<DateTime>? OnTimeChanged;
    private DateTime _simulatedTime;
    private Timer _timer;
    
    public DateTime SimulatedTime
    {
        get => _simulatedTime;
        private set
        {
            if (_simulatedTime != value)
            {
                _simulatedTime = value;
                OnTimeChanged?.Invoke(_simulatedTime);
            }
        }
    }

    /// <summary>
    /// Provides a service to simulate the passage of time, allowing a customizable
    /// DateTime for use in scenarios such as testing or simulations. The time
    /// automatically advances at a fixed interval to mimic real-time progression.
    /// </summary>
    public SimulatedTimeService(DateTime dateTime)
    {
        _simulatedTime = dateTime;

        _timer = new Timer(1000);
        _timer.Elapsed += (sender, args) => UpdateTime();
        _timer.Start();
    }

    private void UpdateTime()
    {
        SimulatedTime = SimulatedTime.AddMinutes(1);
    }
}