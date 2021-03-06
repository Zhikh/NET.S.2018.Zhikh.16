﻿using System;

namespace Task2.Logic.StatePattern
{
    public class GreenState : ILightState
    {
        /// <summary>
        /// Colour of light
        /// </summary>
        public ColourOption Colour => ColourOption.Green;

        /// <summary>
        /// Change state of traffic light on yellow
        /// </summary>
        /// <param name="trafficLight"> Object of traffic light for changing its state </param>
        /// <exception cref="ArgumentNullException"> If trafficLight is null </exception>
        public void Change(TrafficLightState trafficLight)
        {
            if (trafficLight == null)
            {
                throw new ArgumentNullException($"The patametr {nameof(trafficLight)} can't be null!");
            }

            trafficLight.State = new YellowState();
        }
    }
}
