using System;
using System.Collections.Generic;

namespace Task2.Logic.StatePattern
{
    public static class TrafficManager
    {
        /// <summary>
        /// Run cycle of change states for traffic light
        /// </summary>
        /// <param name="initState"> Initial state </param>
        /// <param name="shiftsNumber"> Number of changes states </param>
        /// <returns> Collection of colours </returns>
        /// <exception cref="ArgumentNullException"> If initState is null </exception>
        public static IEnumerable<ColourOption> Start(ILightState initState, int shiftsNumber)
        {
            var trafficLight = new TrafficLightState(initState);

            for (int i = 0; i < shiftsNumber; i++)
            {
                yield return trafficLight.Colour;

                trafficLight.Change();
            }
        }
    }
}
