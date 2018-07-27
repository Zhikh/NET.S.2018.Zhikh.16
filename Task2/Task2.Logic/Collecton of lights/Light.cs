using System;

namespace Task2.Logic
{
    public sealed class Light
    {
        private string _colour;

        /// <summary>
        /// Colour of light
        /// </summary>
        public string Colour
        {
            get
            {
                return _colour;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException($"{nameof(Colour)} can't be null or empty!");
                }

                _colour = value;
            }
        }
    }
}
