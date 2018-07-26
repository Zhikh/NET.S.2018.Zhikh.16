using NUnit.Framework;
using System;
using System.Collections.Generic;
using Task1.Logic;
using Task1.Tests.AdditionalTypes;
using Task1.Tests.Copmarers;

namespace Task1.Tests
{
    [TestFixture]
    public class BinarySearchTreeTests
    {
        #region Test data

        #region Trees
        private static BinarySearchTree<int> intTreeDefault;
        private static BinarySearchTree<int> intTreeCustomer;

        private static BinarySearchTree<string> stringTreeDefault;
        private static BinarySearchTree<string> stringTreeCustomer;
        
        private static BinarySearchTree<Book> bookTreeCustomer;
        #endregion

        #region Books
        private Book[][] _sourceBooks =
        {
            new Book[]
            {
                new Book
                {
                    Name = "Name1",
                    Author = "Author1",
                    Pages = 489
                },
                new Book
                {
                    Name = "Name2",
                    Author = "Author1",
                    Pages = 100
                },
                new Book
                {
                    Name = "Name3",
                    Author = "Author2",
                    Pages = 589
                }
            },
            new Book[]
            {
                new Book
                {
                    Name = "Name1",
                    Author = "Author1",
                    Pages = 489
                },
                new Book
                {
                    Name = "Name2",
                    Author = "Author1",
                    Pages = 100
                },
                new Book
                {
                    Name = "Name3",
                    Author = "Author2",
                    Pages = 589
                },
                new Book
                {
                    Name = "Name4",
                    Author = "Author2",
                    Pages = 489
                }
            },
            new Book[]
            {
                new Book
                {
                    Name = "Name1",
                    Author = "Author1",
                    Pages = 489
                },
                new Book
                {
                    Name = "Name2",
                    Author = "Author1",
                    Pages = 100
                },
                null,
                new Book
                {
                    Name = "Name3",
                    Author = "Author2",
                    Pages = 589
                },
                null,
                new Book
                {
                    Name = "Name4",
                    Author = "Author2",
                    Pages = 489
                },
                new Book
                {
                    Name = "Name5",
                    Author = "Author2",
                    Pages = 200
                }
            }
        };

        private Book[][] _resultPreorder =
        {
            new Book[]
            {
                new Book
                {
                    Name = "Name1",
                    Author = "Author1",
                    Pages = 489
                },
                new Book
                {
                    Name = "Name2",
                    Author = "Author1",
                    Pages = 100
                },
                new Book
                {
                    Name = "Name3",
                    Author = "Author2",
                    Pages = 589
                }
            },
            new Book[]
            {
                new Book
                {
                    Name = "Name1",
                    Author = "Author1",
                    Pages = 489
                },
                new Book
                {
                    Name = "Name2",
                    Author = "Author1",
                    Pages = 100
                },
                new Book
                {
                    Name = "Name3",
                    Author = "Author2",
                    Pages = 589
                },
                new Book
                {
                    Name = "Name4",
                    Author = "Author2",
                    Pages = 489
                }
            },
            new Book[]
            {
                new Book
                {
                    Name = "Name1",
                    Author = "Author1",
                    Pages = 489
                },
                new Book
                {
                    Name = "Name2",
                    Author = "Author1",
                    Pages = 100
                },
                null,
                new Book
                {
                    Name = "Name5",
                    Author = "Author2",
                    Pages = 200
                },
                new Book
                {
                    Name = "Name3",
                    Author = "Author2",
                    Pages = 589
                },
                new Book
                {
                    Name = "Name4",
                    Author = "Author2",
                    Pages = 489
                }
            }
        };

        private Book[][] _resultPostorder =
        {
            new Book[]
            {
                new Book
                {
                    Name = "Name2",
                    Author = "Author1",
                    Pages = 100
                },
                new Book
                {
                    Name = "Name3",
                    Author = "Author2",
                    Pages = 589
                },
                new Book
                {
                    Name = "Name1",
                    Author = "Author1",
                    Pages = 489
                }
            },
            new Book[]
            {
                new Book
                {
                    Name = "Name2",
                    Author = "Author1",
                    Pages = 100
                },
                new Book
                {
                    Name = "Name4",
                    Author = "Author2",
                    Pages = 489
                },
                new Book
                {
                    Name = "Name3",
                    Author = "Author2",
                    Pages = 589
                },
                new Book
                {
                    Name = "Name1",
                    Author = "Author1",
                    Pages = 489
                }
            },
            new Book[]
            {
                null,
                new Book
                {
                    Name = "Name5",
                    Author = "Author2",
                    Pages = 200
                },
                new Book
                {
                    Name = "Name2",
                    Author = "Author1",
                    Pages = 100
                },
                new Book
                {
                    Name = "Name4",
                    Author = "Author2",
                    Pages = 489
                },
                new Book
                {
                    Name = "Name3",
                    Author = "Author2",
                    Pages = 589
                },
                new Book
                {
                    Name = "Name1",
                    Author = "Author1",
                    Pages = 489
                }
            }
        };

        private Book[][] _resultInorder =
        {
            new Book[]
            {
                new Book
                {
                    Name = "Name2",
                    Author = "Author1",
                    Pages = 100
                },
                new Book
                {
                    Name = "Name1",
                    Author = "Author1",
                    Pages = 489
                },
                new Book
                {
                    Name = "Name3",
                    Author = "Author2",
                    Pages = 589
                }
            },
            new Book[]
            {
                new Book
                {
                    Name = "Name2",
                    Author = "Author1",
                    Pages = 100
                },
                new Book
                {
                    Name = "Name1",
                    Author = "Author1",
                    Pages = 489
                },
                new Book
                {
                    Name = "Name4",
                    Author = "Author2",
                    Pages = 489
                },
                new Book
                {
                    Name = "Name3",
                    Author = "Author2",
                    Pages = 589
                }
            },
            new Book[]
            {
                null,
                new Book
                {
                    Name = "Name2",
                    Author = "Author1",
                    Pages = 100
                },
                new Book
                {
                    Name = "Name5",
                    Author = "Author2",
                    Pages = 200
                },
                new Book
                {
                    Name = "Name1",
                    Author = "Author1",
                    Pages = 489
                },
                new Book
                {
                    Name = "Name4",
                    Author = "Author2",
                    Pages = 489
                },
                new Book
                {
                    Name = "Name3",
                    Author = "Author2",
                    Pages = 589
                }
            }
        };
        #endregion

        [SetUp]
        public void Init()
        {
            intTreeDefault = new BinarySearchTree<int>();
            intTreeCustomer = new BinarySearchTree<int>(new IntComparer());

            stringTreeDefault = new BinarySearchTree<string>();
            stringTreeCustomer = new BinarySearchTree<string>(new Copmarers.StringComparer());
            
            bookTreeCustomer = new BinarySearchTree<Book>(new BookComparer());
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
        public IEnumerable<int> Preorder_IntElementDefaultComparer_ElementAdded(int[] values, int length = -1)
        {
            CreateTree(values, intTreeDefault, ref length);

            var inumerator = intTreeDefault.Preorder();

            return GetSequence(length, inumerator);
        }

        [TestCase(new int[] { 1 }, ExpectedResult = new int[] { 1 })]
        [TestCase(new int[] { 2, 0, 1 }, ExpectedResult = new int[] { 2, 0, 1 })]
        [TestCase(new int[] { 5, 6, 3, 7, 2, 4 }, ExpectedResult = new int[] { 5, 6, 7, 3, 4, 2 })]
        public IEnumerable<int> Preorder_IntElementCustomerComparer_ElementAdded(int[] values, int length = -1)
        {
            CreateTree(values, intTreeCustomer, ref length);

            var inumerator = intTreeCustomer.Preorder();

            return GetSequence(length, inumerator);
        }
        #endregion

        #region String
        [TestCase(-1, "b", "a", "c", ExpectedResult = new string[] { "b", "a", "c" })]
        [TestCase(-1, "ab", "abc", "aa", ExpectedResult = new string[] { "ab", "aa", "abc" })]
        [TestCase(3, "ab", "abc", "aba", "aba", ExpectedResult = new string[] { "ab", "abc", "aba" })]
        [TestCase(4, "abd", "aba", "dfg", "dfgk", ExpectedResult = new string[] { "abd", "aba", "dfg", "dfgk" })]
        [TestCase(5, "abd", null, "aba", "aba", null, "aba", "dfg", "dfgk", ExpectedResult = new string[] { "abd", null, "aba", "dfg", "dfgk" })]
        public IEnumerable<string> Preorder_StringElementDefaultComparer_ElementAdded(int length, params string[] values)
        {
            CreateTree(values, stringTreeDefault, ref length);

            var inumerator = stringTreeDefault.Preorder();

            return GetSequence(length, inumerator);
        }

        [TestCase(-1, "b", "a", "c", ExpectedResult = new string[] { "b", "a", "c" })]
        [TestCase(-1, "ab", "abc", "aa", ExpectedResult = new string[] { "ab", "aa", "abc" })]
        [TestCase(3, "ab", "abc", "aba", "aba", ExpectedResult = new string[] { "ab", "abc", "aba" })]
        [TestCase(4, "abd", "aba", "dfg", "dfgk", ExpectedResult = new string[] { "abd", "aba", "dfg", "dfgk" })]
        [TestCase(5, "abd", null, "aba", "aba", null, "aba", "dfg", "dfgk", ExpectedResult = new string[] { "abd", null, "aba", "dfg", "dfgk" })]
        public IEnumerable<string> Preorder_StringElementCustomerComparer_ElementAdded(int length, params string[] values)
        {
            CreateTree(values, stringTreeCustomer, ref length);

            var inumerator = stringTreeCustomer.Preorder();

            return GetSequence(length, inumerator);
        }
        #endregion

        #region Book
        [Test]
        public void Preorder_BookElementCustomerComparer_ElementAdded()
        {
            int i = 0;
            foreach (var array in _sourceBooks)
            {
                int length = _resultPreorder[i].Length;
                CreateTree(array, bookTreeCustomer, ref length);

                var inumerator = bookTreeCustomer.Preorder();
                var actual =  GetSequence(length, inumerator);

                CollectionAssert.AreEqual(_resultPreorder[i++], actual);
            }
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
        public IEnumerable<int> Postorder_IntElementDefaultComparer_ElementAdded(int[] values, int length = -1)
        {
            CreateTree(values, intTreeDefault, ref length);

            var inumerator = intTreeDefault.Postorder();

            return GetSequence(length, inumerator);
        }

        [TestCase(new int[] { 1 }, ExpectedResult = new int[] { 1 })]
        [TestCase(new int[] { 2, 0, 1 }, ExpectedResult = new int[] { 1, 0, 2 })]
        [TestCase(new int[] { 5, 6, 3, 7, 2, 4 }, ExpectedResult = new int[] { 7, 6, 4, 2, 3, 5})]
        public IEnumerable<int> Postorder_IntElementCustomerComparer_ElementAdded(int[] values, int length = -1)
        {
            CreateTree(values, intTreeCustomer, ref length);

            var inumerator = intTreeCustomer.Postorder();

            return GetSequence(length, inumerator);
        }
        #endregion

        #region String
        [TestCase(-1, "b", "a", "c", ExpectedResult = new string[] { "a", "c", "b" })]
        [TestCase(-1, "ab", "abc", "aa", ExpectedResult = new string[] { "aa", "abc", "ab" })]
        [TestCase(3, "ab", "abc", "aba", "aba", ExpectedResult = new string[] { "aba", "abc", "ab" })]
        [TestCase(4, "abd", "aba", "dfg", "dfgk", ExpectedResult = new string[] { "aba", "dfgk", "dfg", "abd" })]
        [TestCase(5, "abd", null, "aba", "aba", null, "aba", "dfg", "dfgk", ExpectedResult = new string[] { "aba", null, "dfgk", "dfg", "abd" })]
        public IEnumerable<string> Postorder_StringElementDefaultComparer_ElementAdded(int length, params string[] values)
        {
            CreateTree(values, stringTreeDefault, ref length);

            var inumerator = stringTreeDefault.Postorder();

            return GetSequence(length, inumerator);
        }

        [TestCase(-1, "b", "a", "c", ExpectedResult = new string[] { "a", "c", "b" })]
        [TestCase(-1, "ab", "abc", "aa", ExpectedResult = new string[] { "aa", "abc", "ab" })]
        [TestCase(3, "ab", "abc", "aba", "aba", ExpectedResult = new string[] { "aba", "abc", "ab" })]
        [TestCase(4, "abd", "aba", "dfg", "dfgk", ExpectedResult = new string[] { "aba", "dfgk", "dfg", "abd" })]
        [TestCase(5, "abd", null, "aba", "aba", null, "aba", "dfg", "dfgk", ExpectedResult = new string[] { "aba", null, "dfgk", "dfg", "abd" })]
        public IEnumerable<string> Postorder_StringElementCustomerComparer_ElementAdded(int length, params string[] values)
        {
            CreateTree(values, stringTreeCustomer, ref length);

            var inumerator = stringTreeCustomer.Postorder();

            return GetSequence(length, inumerator);
        }
        #endregion

        #region Book
        [Test]
        public void Postorder_BookElementCustomerComparer_ElementAdded()
        {
            int i = 0;
            foreach (var array in _sourceBooks)
            {
                int length = _resultPostorder[i].Length;
                CreateTree(array, bookTreeCustomer, ref length);

                var inumerator = bookTreeCustomer.Postorder();
                var actual = GetSequence(length, inumerator);

                CollectionAssert.AreEqual(_resultPostorder[i++], actual);
            }
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
        public IEnumerable<int> Inorder_IntElementDefaultComparer_ElementAdded(int[] values, int length = -1)
        {
            CreateTree(values, intTreeDefault, ref length);

            var inumerator = intTreeDefault.Inorder();

            return GetSequence(length, inumerator);
        }

        [TestCase(new int[] { 1 }, ExpectedResult = new int[] { 1 })]
        [TestCase(new int[] { 2, 0, 1 }, ExpectedResult = new int[] { 2, 1, 0 })]
        [TestCase(new int[] { 5, 6, 3, 7, 2, 4 }, ExpectedResult = new int[] { 7, 6, 5, 4, 3, 2 })]
        public IEnumerable<int> Inorder_IntElementCustomerComparer_ElementAdded(int[] values, int length = -1)
        {
            CreateTree(values, intTreeCustomer, ref length);

            var inumerator = intTreeCustomer.Inorder();

            return GetSequence(length, inumerator);
        }
        #endregion

        #region String
        [TestCase(-1, "b", "a", "c", ExpectedResult = new string[] { "a", "b", "c" })]
        [TestCase(-1, "ab", "abc", "aa", ExpectedResult = new string[] { "aa", "ab", "abc" })]
        [TestCase(3, "ab", "abc", "aba", "aba", ExpectedResult = new string[] { "ab", "aba", "abc" })]
        [TestCase(4, "abd", "aba", "dfg", "dfgk", ExpectedResult = new string[] { "aba", "abd", "dfg", "dfgk" })]
        [TestCase(5, "abd", null, "aba", "aba", null, "aba", "dfg", "dfgk", ExpectedResult = new string[] { null, "aba", "abd", "dfg", "dfgk" })]
        public IEnumerable<string> Inorder_StringElementDefaultComparer_ElementAdded(int length, params string[] values)
        {
            CreateTree(values, stringTreeDefault, ref length);

            var inumerator = stringTreeDefault.Inorder();

            return GetSequence(length, inumerator);
        }

        [TestCase(-1, "b", "a", "c", ExpectedResult = new string[] { "a", "b", "c" })]
        [TestCase(-1, "ab", "abc", "aa", ExpectedResult = new string[] { "aa", "ab", "abc" })]
        [TestCase(3, "ab", "abc", "aba", "aba", ExpectedResult = new string[] { "ab", "aba", "abc" })]
        [TestCase(4, "abd", "aba", "dfg", "dfgk", ExpectedResult = new string[] { "aba", "abd", "dfg", "dfgk" })]
        [TestCase(5, "abd", null, "aba", "aba", null, "aba", "dfg", "dfgk", ExpectedResult = new string[] { null, "aba", "abd", "dfg", "dfgk" })]
        public IEnumerable<string> Inorder_StringElementCustomerComparer_ElementAdded(int length, params string[] values)
        {
            CreateTree(values, stringTreeCustomer, ref length);

            var inumerator = stringTreeCustomer.Inorder();

            return GetSequence(length, inumerator);
        }
        #endregion

        #region Book
        [Test]
        public void Inorder_BookElementCustomerComparer_ElementAdded()
        {
            int i = 0;
            foreach (var array in _sourceBooks)
            {
                int length = _resultInorder[i].Length;
                CreateTree(array, bookTreeCustomer, ref length);

                var inumerator = bookTreeCustomer.Inorder();
                var actual = GetSequence(length, inumerator);

                CollectionAssert.AreEqual(_resultInorder[i++], actual);
            }
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

            if (length == -1)
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
