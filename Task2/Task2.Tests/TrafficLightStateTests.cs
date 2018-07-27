using NUnit.Framework;
using Task2.Logic.StatePattern;

namespace Task2.Tests
{
    [TestFixture]
    class TrafficLightStateTests
    {
        #region Test data

        #endregion

        [Test]
        public void ChangeState()
        {
            TrafficLightState trafficLight = new TrafficLightState(new RedState());
            trafficLight.Change();
        }
    }
}
