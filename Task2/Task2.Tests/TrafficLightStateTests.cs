using NUnit.Framework;
using Task2.Logic.StatePattern;

namespace Task2.Tests
{
    [TestFixture]
    class TrafficLightStateTests
    {
        #region Test data
        static object[] _initStates =
        {
            new object[] { new RedState(), 1,
                new ColourOption[] { ColourOption.Red } },
            new object[] { new RedState(), 2,
                new ColourOption[] { ColourOption.Red, ColourOption.RedAndYellow }},
            new object[] { new RedState(), 4,
                new ColourOption[] { ColourOption.Red, ColourOption.RedAndYellow, ColourOption.Green, ColourOption.Yellow }},
             new object[] { new RedYellowState(), 6,
                 new ColourOption[] { ColourOption.RedAndYellow, ColourOption.Green, ColourOption.Yellow, ColourOption.Red, ColourOption.RedAndYellow, ColourOption.Green} },
        };
        #endregion

        [Test, TestCaseSource("_initStates")]
        public void ChangeState(ILightState state, int changesCount, ColourOption[] colours)
        {
            var actual = TrafficManager.Start(state, changesCount);

            int i = 0;
            foreach (var element in actual)
            {
                Assert.AreEqual(element, colours[i++]);
            }
        }
    }
}
