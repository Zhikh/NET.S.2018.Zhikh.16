using System;
using Task2.Logic.StatePattern;

namespace Task2.Logic.Events
{
    public abstract class BaseLight
    {
        protected BaseLight(ColourOption colour)
        {
            Colour = colour;
        }

        public ColourOption Colour { get; }

        public event EventHandler<LightArgs> LightChanged = delegate { };

        public void Change()
        {
            OnLightChange(this, new LightArgs(Colour));
        }

        protected virtual void OnLightChange(object sender, LightArgs eventArgs)
        {
            LightChanged?.Invoke(sender, eventArgs);
        }
    }
}
