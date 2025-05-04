using System.Reflection;

namespace SftEngGP.Test;

public class TestableSimulatedTimeService : SimulatedTimeService
{
    public TestableSimulatedTimeService(DateTime initialTime) : base(initialTime)
    {
        StopAutoAdvance();
    }
    
    public void SetTime(DateTime newTime)
        {
            SimulatedTime = newTime;
            Console.WriteLine($"SimulatedTime set to: {SimulatedTime}");
        }
    
    private void StopAutoAdvance()
    {
        typeof(SimulatedTimeService)
            .GetField("_timer", BindingFlags.NonPublic | BindingFlags.Instance)?
            .SetValue(this, null);
    }

    public void TriggerTimeUpdate()
    {
        typeof(SimulatedTimeService)
            .GetMethod("UpdateTime", BindingFlags.NonPublic | BindingFlags.Instance)?
            .Invoke(this, null);
    }
}
