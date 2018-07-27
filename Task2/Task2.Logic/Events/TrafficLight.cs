using Task2.Logic.StatePattern;

namespace Task2.Logic.Events
{
    public class TrafficLight : BaseLightObserver
    {
        public ColourOption Colour { get; private set; }

        protected override void LightChanged(object sender, LightArgs e)
        {
            Colour = e.Colour;
        }
    }
}
