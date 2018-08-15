using System.Collections.Generic;

namespace Task1.Tests.Copmarers
{
    public class IntComparer : IComparer<int>
    {
        /// <summary>
        /// Compare two books by number of pages
        /// </summary>
        /// <param name="left"> First element to copmare </param>
        /// <param name="right"> Second element to compare </param>
        /// <returns> 
        /// A signed integer that indicates the relative values of left and right, as shown in the
        /// following table.Value Meaning Less than zero left is less than right. Zero left equals right. Greater
        /// than zero left is greater than right. 
        /// </returns>
        public int Compare(int left, int right)
        {
            if (left > right)
            {
                return -1;
            }

            if (left < right)
            {
                return 1;
            }

            return 0;
        }
    }
}
