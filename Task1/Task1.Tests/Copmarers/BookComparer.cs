using System.Collections.Generic;
using Task1.Tests.AdditionalTypes;

namespace Task1.Tests.Copmarers
{
    class BookComparer : IComparer<Book>
    {
        /// <summary>
        /// Compare two books by number of pages
        /// </summary>
        /// <param name="left"> First book to compare </param>
        /// <param name="right"> Second book to compare </param>
        /// <returns> 
        /// A signed integer that indicates the relative values of left and right, as shown in the
        /// following table.Value Meaning Less than zero left is less than right. Zero left equals right. Greater
        /// than zero left is greater than right. 
        /// </returns>
        public int Compare(Book left, Book right)
        {
            if (left == null && right == null)
            {
                return 0;
            }

            if (left == null)
            {
                return -1;
            }

            if (right == null)
            {
                return 1;
            }

            if (left.Pages < right.Pages)
            {
                return -1;
            }

            if (left.Pages> right.Pages)
            {
                return 1;
            }
            
            StringComparer comparer = new StringComparer();

            return comparer.Compare(left.Name, right.Name);
        }
    }
}
