namespace SftEngGP.Test;

public class TestableSimulatedTimeService : SimulatedTimeService
{
    public TestableSimulatedTimeService(DateTime initialTime) : base(initialTime)
    {
        StopAutoAdvance();
    }
    
    private void StopAutoAdvance()
    {
        typeof(SimulatedTimeService)
            .GetField("_timer", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)?
            .SetValue(this, null);
    }

    public void TriggerTimeChange(DateTime newTime)
    {
        typeof(SimulatedTimeService)
            .GetProperty("SimulatedTime", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)?
            .SetValue(this, newTime);
    }
}
