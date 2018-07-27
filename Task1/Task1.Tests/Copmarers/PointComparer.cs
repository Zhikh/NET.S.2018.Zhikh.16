using System.Collections.Generic;
using Task1.Tests.AdditionalTypes;

namespace Task1.Tests.Copmarers
{
    public sealed class PointComparer : IComparer<Point>
    {
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
