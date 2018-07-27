using Task2.Logic.StatePattern;

namespace Task2.Logic.Events
{
    public sealed class GreenLight : BaseLight
    {
        public GreenLight() : base(ColourOption.Green)
        {
        }
    }
}
