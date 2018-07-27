using NUnit.Framework;
using Task2.Logic;

namespace Task2.Tests
{
    [TestFixture]
    public class TrafficLightCollectionTests
    {
        #region Test data
        private bool[][] _autoTrafficLightRules = 
        {
            new bool[]
            {
                true, false, false
            },
            new bool[]
            {
                true, true, false
            },
            new bool[]
            {
                false, false, true
            },
            new bool[]
            {
                false, true, false
            }
        };

        private Light[] _autoTrafficLights =
        {
            new Light
            {
                Color = "Red",
            },
            new Light
            {
                Color = "Yellow",
            },
            new Light
            {
                Color = "Green",
            },
        };

        private string[][] _autoTrafficResult =
        {
            new string[]
            {
                "Red"
            },
            new string[]
            {
                "Red", "Yellow"
            },
            new string[]
            {
                "Green"
            },
            new string[]
            {
                "Yellow"
            }
        };
        #endregion

        #region Tests
        [Test]
        public void GetIterator_TrafficLightsAndRules_CorrectOrderOfTurningOnLights()
        {
            var trafficLight = new TrafficLightCollection(_autoTrafficLights, _autoTrafficLightRules);

            int i = 0;
            foreach(var lights in trafficLight)
            {
                if (lights.Length != _autoTrafficResult[i].Length)
                {
                    Assert.Fail($"Values differ at index [{i}]");
                }

                int j = 0;
                foreach(var light in lights)
                {
                    Assert.AreEqual(_autoTrafficResult[i][j++], light.Color);
                }
                i++;
            }
        }
        #endregion
    }
}
