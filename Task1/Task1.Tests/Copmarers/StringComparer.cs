using System.Collections.Generic;

namespace Task1.Tests.Copmarers
{
    class StringComparer : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            if (x == null && y == null)
            {
                return 0;
            }

            if (x == null)
            {
                return -1;
            }

            if (y == null)
            {
                return 1;
            }

            if (x[0] < y[0])
            {
                return -1;
            }

            if (x[0] > y[0])
            {
                return 1;
            }

            return CompareByLength(x, y);
        }

        private int CompareByLength(string x, string y)
        {
            int xLength = x.Length;
            int yLength = y.Length;
            if (xLength < yLength)
            {
                return -1;
            }

            if (xLength > yLength)
            {
                return 1;
            }

            for (int i = 0; i < xLength; i++)
            {
                if (x[i] < y[i])
                {
                    return -1;
                }

                if (x[i] > y[i])
                {
                    return 1;
                }
            }

            return 0;
        }
    }
}
