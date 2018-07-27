using System;

namespace Task2.Logic
{
    public sealed class Light
    {
        private string _color;

        public string Color
        {
            get
            {
                return _color;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException($"{nameof(Color)} can't be null or empty!");
                }

                _color = value;
            }
        }
    }
}
