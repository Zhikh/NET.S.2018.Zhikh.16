using NUnit.Framework;
using System.Collections.Generic;
using Task1.Logic;
using Task1.Tests.Copmarers;

namespace Task1.Tests
{
    [TestFixture]
    public class BinarySearchTreeTests
    {
        #region Test data
        private static BinarySearchTree<int> intTreeDefault;
        private static BinarySearchTree<int> intTreeCustomer;

        private static BinarySearchTree<string> stringTreeDefault;
        private static BinarySearchTree<string> stringTreeCustomer;

        [SetUp]
        public void Init()
        {
            intTreeDefault = new BinarySearchTree<int>();
            intTreeCustomer = new BinarySearchTree<int>(new IntComparer());

            stringTreeDefault = new BinarySearchTree<string>();
            stringTreeCustomer = new BinarySearchTree<string>(new Copmarers.StringComparer());
        }
        #endregion

        #region Tests

        #region Exceptions
        #endregion

        #region Preorder 

        #region Integer
        [TestCase(new int[] { 1 }, ExpectedResult = new int[]{ 1 })]
        [TestCase(new int[] { 2, 0, 1 }, ExpectedResult = new int[] { 2, 0, 1 })]
        [TestCase(new int[] { 5, 6, 3, 7, 2, 4 }, ExpectedResult = new int[] { 5, 3, 2, 4, 6, 7 })]
        [TestCase(new int[] { 60, 40, 31, 72, 20, 40, 53, 64, 721, 1, 21, 0, -1, 3, 0}, 13,
            ExpectedResult = new int[] { 60, 40, 31, 20, 1, 0, -1, 3, 21, 53, 72, 64, 721 })]
        public IEnumerable<int> Preorder_IntElementDefaultComparer_ElementAdded(int[] values, int length = 0)
        {
            CreateTree(values, intTreeDefault, ref length);

            var inumerator = intTreeDefault.Preorder();

            return GetSequence(length, inumerator);
        }

        [TestCase(new int[] { 1 }, ExpectedResult = new int[] { 1 })]
        [TestCase(new int[] { 2, 0, 1 }, ExpectedResult = new int[] { 2, 0, 1 })]
        [TestCase(new int[] { 5, 6, 3, 7, 2, 4 }, ExpectedResult = new int[] { 5, 6, 7, 3, 4, 2 })]
        public IEnumerable<int> Preorder_IntElementCustomerComparer_ElementAdded(int[] values, int length = 0)
        {
            CreateTree(values, intTreeCustomer, ref length);

            var inumerator = intTreeCustomer.Preorder();

            return GetSequence(length, inumerator);
        }
        #endregion

        #endregion

        #region Postorder

        #region Integer
        [TestCase(new int[] { 1 }, ExpectedResult = new int[] { 1 })]
        [TestCase(new int[] { 2, 0, 1 }, ExpectedResult = new int[] { 1, 0, 2 })]
        [TestCase(new int[] { 5, 6, 3, 7, 2, 4 }, ExpectedResult = new int[] { 2, 4, 3, 7, 6, 5 })]
        [TestCase(new int[] { 60, 40, 31, 72, 20, 40, 53, 64, 721, 1, 21, 0, -1, 3, 0 }, 13,
            ExpectedResult = new int[] { -1, 0, 3, 1, 21, 20, 31, 53, 40, 64, 721, 72, 60 })]
        public IEnumerable<int> Postorder_IntElementDefaultComparer_ElementAdded(int[] values, int length = 0)
        {
            CreateTree(values, intTreeDefault, ref length);

            var inumerator = intTreeDefault.Postorder();

            return GetSequence(length, inumerator);
        }

        [TestCase(new int[] { 1 }, ExpectedResult = new int[] { 1 })]
        [TestCase(new int[] { 2, 0, 1 }, ExpectedResult = new int[] { 1, 0, 2 })]
        [TestCase(new int[] { 5, 6, 3, 7, 2, 4 }, ExpectedResult = new int[] { 7, 6, 4, 2, 3, 5})]
        public IEnumerable<int> Postorder_IntElementCustomerComparer_ElementAdded(int[] values, int length = 0)
        {
            CreateTree(values, intTreeCustomer, ref length);

            var inumerator = intTreeCustomer.Postorder();

            return GetSequence(length, inumerator);
        }
        #endregion

        #endregion

        #region Inorder

        #region Integer
        [TestCase(new int[] { 1 }, ExpectedResult = new int[] { 1 })]
        [TestCase(new int[] { 2, 0, 1 }, ExpectedResult = new int[] { 0, 1, 2 })]
        [TestCase(new int[] { 5, 6, 3, 7, 2, 4 }, ExpectedResult = new int[] { 2, 3, 4, 5, 6, 7 })]
        [TestCase(new int[] { 60, 40, 31, 72, 20, 40, 53, 64, 721, 1, 21, 0, -1, 3, 0 }, 13,
            ExpectedResult = new int[] { -1, 0, 1, 3, 20, 21, 31, 40, 53, 60, 64, 72, 721 })]
        public IEnumerable<int> Inorder_IntElementDefaultComparer_ElementAdded(int[] values, int length = 0)
        {
            CreateTree(values, intTreeDefault, ref length);

            var inumerator = intTreeDefault.Inorder();

            return GetSequence(length, inumerator);
        }

        [TestCase(new int[] { 1 }, ExpectedResult = new int[] { 1 })]
        [TestCase(new int[] { 2, 0, 1 }, ExpectedResult = new int[] { 2, 1, 0 })]
        [TestCase(new int[] { 5, 6, 3, 7, 2, 4 }, ExpectedResult = new int[] { 7, 6, 5, 4, 3, 2 })]
        public IEnumerable<int> Inorder_IntElementCustomerComparer_ElementAdded(int[] values, int length = 0)
        {
            CreateTree(values, intTreeCustomer, ref length);

            var inumerator = intTreeCustomer.Inorder();

            return GetSequence(length, inumerator);
        }
        #endregion

        #endregion

        #endregion

        #region Additional methods
        private static void CreateTree<T>(T[] values, BinarySearchTree<T> tree, ref int length)
        {
            foreach (var value in values)
            {
                tree.Add(value);
            }

            if (length == 0)
            {
                length = values.Length;
            }
        }

        private static IEnumerable<T> GetSequence<T>(int length, IEnumerable<T> inumerator)
        {
            T[] actual = new T[length];
            int i = 0;
            foreach (var element in inumerator)
            {
                actual[i++] = element;
            }

            return actual;
        }
        #endregion
    }
}
