using System;
using Xunit;
using Xunit.Abstractions;

namespace SftEngGP.Test
{
    public class SimulatedTimeServiceTests
    {
        [Fact]
        public void Constructor_SetsInitialTimeCorrectly()
        {
            var initialTime = new DateTime(2024, 1, 1, 12, 0, 0);
            var service = new TestableSimulatedTimeService(initialTime);
            
            var currentSimulatedTime = service.SimulatedTime;
            
            Assert.Equal(initialTime, currentSimulatedTime);
        }

        [Fact]
        public void UpdateTime_ManuallyIncreasesSimulatedTimeByOneMinute()
        {
            var initialTime = new DateTime(2024, 1, 1, 12, 0, 0);
            var service = new TestableSimulatedTimeService(initialTime);
            
            service.TriggerTimeUpdate();
            
            var expectedTime = initialTime.AddMinutes(1);
            Assert.Equal(expectedTime, service.SimulatedTime);
        }
    }
}