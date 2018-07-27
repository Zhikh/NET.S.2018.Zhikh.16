namespace Task2.Logic.StatePattern
{
    /// <summary>
    /// Colour of light
    /// </summary>
    public enum ColourOption
    {
        Red,
        RedAndYellow,
        Green,
        Yellow
    }

    /// <summary>
    /// State for light
    /// </summary>
    public interface ILightState
    {
        /// <summary>
        /// Colour of light
        /// </summary>
        ColourOption Colour { get; }

        /// <summary>
        /// Change state of traffic light
        /// </summary>
        /// <param name="trafficLight"> Object of traffic light for changing its state </param>
        void Change(TrafficLightState trafficLight);
    }
}
