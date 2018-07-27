using Task2.Logic.StatePattern;

namespace Task2.Logic.Events
{
    public class TrafficLight : BaseLightObserver
    {
        /// <summary>
        /// Current colour of traffic light
        /// </summary>
        public ColourOption Colour { get; private set; }

        /// <summary>
        /// Event handler of changing of light
        /// </summary>
        /// <param name="sender"> Object that has inited event </param>
        /// <param name="e"> Event arguments </param>
        protected override void LightChanged(object sender, LightArgs e)
        {
            Colour = e.Colour;
        }
    }
}
