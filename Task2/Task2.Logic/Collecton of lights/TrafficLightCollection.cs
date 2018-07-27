using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Task2.Logic
{
    public class TrafficLightCollection : IEnumerable<Light[]>
    {
        private Light[] _lights;
        private bool[][] _rules;

        /// <summary>
        /// Initialize TrafficLightCollection object
        /// </summary>
        /// <param name="lights"> Set of lights in traffic light </param>
        /// <param name="rules"> Rules of turning on/off light: false - off, true - on. 
        /// Index rule element should be equal index of light </param>
        /// <exception cref="ArgumentNullException"> 
        /// If lights is null,
        /// if rules are null,
        /// if one of rules is null
        /// </exception>
        /// <exception cref="ArgumentException"> If rule invalid for traffic light </exception>
        public TrafficLightCollection(IEnumerable<Light> lights, bool[][] rules)
        {
            if (lights == null)
            {
                throw new ArgumentNullException($"The parametr {nameof(lights)} can't be null!");
            }

            if (rules == null)
            {
                throw new ArgumentNullException($"The parametr {nameof(rules)} can't be null!");
            }

            foreach (var rule in rules)
            {
                if (rule == null)
                {
                    throw new ArgumentNullException($"The parametr {nameof(rule)} can't be null!");
                }

                if (rule.Length != lights.Count())
                {
                    throw new ArgumentException("There is an invalid rule in rules set!");
                }
            }

            _lights = new Light[lights.Count()];
            _rules = new bool[rules.Length][];
            Count = lights.Count();

            Array.Copy(lights.ToArray(), _lights, lights.Count());
            Array.Copy(rules, _rules, rules.Count());
        }

        /// <summary>
        /// Number of lights
        /// </summary>
        public int Count { get; }

        /// <summary>
        /// Get lights for current rule
        /// </summary>
        /// <returns> Set of lights that are turned on </returns>
        public IEnumerator<Light[]> GetEnumerator()
        {
            foreach (var rule in _rules)
            {
                var temp = new List<Light>();
                GetTurnedLights(rule, temp);

                yield return temp.ToArray<Light>();
            }
        }

        /// <summary>
        /// Get lights for current rule
        /// </summary>
        /// <returns> Set of lights that are turned on </returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #region Private methods
        private void GetTurnedLights(bool[] rule, List<Light> temp)
        {
            for (int i = 0; i < Count; i++)
            {
                if (rule[i])
                {
                    temp.Add(_lights[i]);
                }
            }
        }
        #endregion
    }
}
