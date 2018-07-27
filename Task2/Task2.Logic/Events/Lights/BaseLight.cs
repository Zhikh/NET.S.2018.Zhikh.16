using System;
using Task2.Logic.StatePattern;

namespace Task2.Logic.Events
{
    public abstract class BaseLight
    {
        /// <summary>
        /// Initialize colour of light
        /// </summary>
        /// <param name="colour"> Light colour </param>
        protected BaseLight(ColourOption colour)
        {
            Colour = colour;
        }

        /// <summary>
        /// Light colour
        /// </summary>
        public ColourOption Colour { get; }

        /// <summary>
        /// Event of light change
        /// </summary>
        public event EventHandler<LightArgs> LightChanged = delegate { };

        /// <summary>
        /// Set light for traffic light
        /// </summary>
        public void Set()
        {
            OnLightChange(this, new LightArgs(Colour));
        }

        /// <summary>
        /// Invoke listeners
        /// </summary>
        /// <param name="sender"> Initializer of event </param>
        /// <param name="eventArgs"> Event arguments </param>
        protected virtual void OnLightChange(object sender, LightArgs eventArgs)
        {
            LightChanged?.Invoke(sender, eventArgs);
        }
    }
}
