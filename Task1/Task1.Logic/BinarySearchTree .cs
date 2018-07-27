using System;
using System.Collections.Generic;

namespace Task1.Logic
{
    /// <summary>
    /// Unbalanced tree
    /// </summary>
    /// <typeparam name="T"> Type of value for inserting </typeparam>
    public sealed class BinarySearchTree<T>
    {
        #region Fields
        private Node<T> _head;
        private IComparer<T> _comparer;
        #endregion

        #region Public methods
        /// <summary>
        /// Initialize BinarySearchTree
        /// </summary>
        /// <param name="comparer"> Protocol for comparing values of type T </param>
        /// <exception cref="ArgumentNullException"> If T hasn't default comparer </exception>
        public BinarySearchTree(IComparer<T> comparer = null)
        {
            _comparer = comparer ?? 
                (Comparer<T>.Default as IComparer<T> ?? 
                throw new ArgumentNullException("Comparer's indefined for type of T!"));
        }

        /// <summary>
        /// Initialize BinarySearchTree
        /// </summary>
        /// <param name="value"> Value for inserting </param>
        /// <param name="comparer"> Protocol for comparing values of type T </param>
        /// <exception cref="ArgumentNullException"> If T hasn't default comparer </exception>
        public BinarySearchTree(T value, IComparer<T> comparer = null) : this(comparer)
        {
            _head = new Node<T>
            {
                Value = value
            };

            Count++;
        }

        /// <summary>
        /// Count of elements in tree
        /// </summary>
        public int Count { get; private set; }

        /// <summary>
        /// Add value to tree
        /// </summary>
        /// <param name="value"> Value for inserting </param>
        public void Add(T value)
        {
            var node = new Node<T>()
            {
                Value = value
            };

            if (_head == null)
            {
                _head = node;
                return;
            }

            int result = 0;
            
            Node<T> current = _head, parent = null;
            while (current != null)
            {
                result = _comparer.Compare(current.Value, value);
                if (result == 0)
                {
                    return;
                }
                else if (result > 0)
                {
                    parent = current;
                    current = current.Left;
                }
                else if (result < 0)
                {
                    parent = current;
                    current = current.Right;
                }
            }
            
            Count++;
            if (result > 0)
            {
                parent.Left = node;
            }
            else
            {
                parent.Right = node;
            }
        }

        /// <summary>
        /// Use in base preorder of tree
        /// </summary>
        /// <returns> IEnumerator </returns>
        /// <exception cref="InvalidOperationException"> If tree hasn't any element! </exception>
        public IEnumerator<T> GetEnumerator()
        {
            return Preorder().GetEnumerator();
        }

        /// <summary>
        /// Move in direction of: root, left child, right child
        /// </summary>
        /// <returns> Collection of elements of tree </returns>
        /// <exception cref="InvalidOperationException"> If tree hasn't any element! </exception>
        public IEnumerable<T> Preorder()
        {
            if (_head == null)
            {
                throw new InvalidOperationException($"Object of {nameof(BinarySearchTree<T>)} haven't any element!");
            }

            return GetValuePreorder(_head);
        }

        /// <summary>
        /// Move in direction of: left child, root, right child
        /// </summary>
        /// <returns> Collection of elements of tree </returns>
        /// <exception cref="InvalidOperationException"> If tree hasn't any element! </exception>
        public IEnumerable<T> Inorder()
        {
            if (_head == null)
            {
                throw new InvalidOperationException($"Object of {nameof(BinarySearchTree<T>)} haven't any element!");
            }

            return GetValueInorder(_head);
        }

        /// <summary>
        /// Move in direction of: left child, right child, root
        /// </summary>
        /// <returns> Collection of elements of tree </returns>
        /// <exception cref="InvalidOperationException"> If tree hasn't any element! </exception>
        public IEnumerable<T> Postorder()
        {
            if (_head == null)
            {
                throw new InvalidOperationException($"Object of {nameof(BinarySearchTree<T>)} haven't any element!");
            }

            return GetValuePostorder(_head);
        }
        
        public void Remove(T value)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Private method
        // root, left child, right child
        private IEnumerable<T> GetValuePreorder(Node<T> node)
        {
            if (node != null)
            {
                yield return node.Value;

                foreach (var element in GetValuePreorder(node.Left))
                {
                    yield return element;
                }

                foreach (var element in GetValuePreorder(node.Right))
                {
                    yield return element;
                }
            }
        }

        // left child, root, right child
        private IEnumerable<T> GetValueInorder(Node<T> node)
        {
            if (node != null)
            {
                foreach (var element in GetValueInorder(node.Left))
                {
                    yield return element;
                }

                yield return node.Value;

                foreach (var element in GetValueInorder(node.Right))
                {
                    yield return element;
                }
            }
        }

        // left child, right child, root
        private IEnumerable<T> GetValuePostorder(Node<T> node)
        {
            if (node != null)
            {
                foreach (var element in GetValuePostorder(node.Left))
                {
                    yield return element;
                }

                foreach (var element in GetValuePostorder(node.Right))
                {
                    yield return element;
                }

                yield return node.Value;
            }
        }
        #endregion
    }
}
