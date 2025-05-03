using System;
using System.Timers;
using Timer = System.Timers.Timer;

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