using System;

namespace Task2.Logic.StatePattern
{
    public class RedState : ILightState
    {
        /// <summary>
        /// State for light
        /// </summary>
        public ColourOption Colour => ColourOption.Red;

        /// <summary>
        /// Change state of traffic light on red and yelow
        /// </summary>
        /// <param name="trafficLight"> Object of traffic light for changing its state </param>
        /// <exception cref="ArgumentNullException"> If trafficLight is null </exception>
        public void Change(TrafficLightState trafficLight)
        {
            if (trafficLight == null)
            {
                throw new ArgumentNullException($"The patametr {nameof(trafficLight)} can't be null!");
            }

            trafficLight.State = new RedYellowState();
        }
    }
}
