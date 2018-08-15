using System.Collections.Generic;
using Task1.Tests.AdditionalTypes;

namespace Task1.Tests.Copmarers
{
    public sealed class PointComparer : IComparer<Point>
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
        public int Compare(Point left, Point right)
        {
            int leftSum = left.X + left.Y;
            int rightSum = right.X + right.Y;

            if (leftSum < rightSum)
            {
                return -1;
            }

            if (leftSum > rightSum)
            {
                return 1;
            }

            return 0;
        }
    }
}
