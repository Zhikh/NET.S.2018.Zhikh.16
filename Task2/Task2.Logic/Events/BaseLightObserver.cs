using System;

namespace Task2.Logic.Events
{
    public abstract class BaseLightObserver
    {
        /// <summary>
        /// Add new listener
        /// </summary>
        /// <param name="light"> Object for listening </param>
        public void Register(BaseLight light)
        {
            if (light == null)
            {
                throw new ArgumentNullException($"Paramentr {nameof(light)} can't be null!");
            }

            light.LightChanged += LightChanged;
        }

        /// <summary>
        /// Delete listener
        /// </summary>
        /// <param name="light"> Object for listening </param>
        public void UnRegister(BaseLight light)
        {
            if (light == null)
            {
                throw new ArgumentNullException($"Paramentr {nameof(light)} can't be null!");
            }

            light.LightChanged -= LightChanged;
        }

        /// <summary>
        /// Execute when clock time out event is happened
        /// </summary>
        /// <param name="sender"> Object who created event </param>
        /// <param name="e"> Event inforfation </param>
        protected abstract void LightChanged(object sender, LightArgs e);
    }
}
