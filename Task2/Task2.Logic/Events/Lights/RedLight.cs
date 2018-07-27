using Task2.Logic.StatePattern;

namespace Task2.Logic.Events
{
    public sealed class RedLight : BaseLight
    {
        public RedLight() : base(ColourOption.Red)
        {
        }
    }
}
