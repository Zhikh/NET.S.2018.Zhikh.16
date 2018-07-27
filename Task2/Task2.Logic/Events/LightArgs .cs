using System;
using Task2.Logic.StatePattern;

namespace Task2.Logic.Events
{
    public class LightArgs : EventArgs
    {
        public LightArgs(ColourOption colour)
        {
            if (colour < 0)
            {
                throw new ArgumentException($"The parametr {nameof(colour)} can't be negative value!");
            }

            Colour = colour;
        }

        public ColourOption Colour { get; }
    }
}
