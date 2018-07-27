using System;

namespace Task2.Logic.StatePattern
{
    public class TrafficLightState
    {
        private ILightState _state;
        
        /// <summary>
        /// Initialize TrafficLightState by initial state
        /// </summary>
        /// <param name="state"> State of traffic light </param>
        public TrafficLightState(ILightState state)
        {
            State = state;
        }

        /// <summary>
        /// State of traffic light
        /// </summary>
        public ILightState State
        {
            get
            {
                return _state;
            }

            set
            {
                _state = value ?? throw new ArgumentNullException($"The {nameof(State)} can't be null!");
            }
        }

        /// <summary>
        /// Current colour
        /// </summary>
        public ColourOption Colour => State.Colour;

        /// <summary>
        /// Change state of traffic light
        /// </summary>
        public void Change()
        {
            State.Change(this);
        }
    }
}
