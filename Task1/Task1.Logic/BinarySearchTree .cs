using System;
using System.Collections.Generic;

namespace Task1.Logic
{
    public sealed class BinarySearchTree<T>
    {
        private Node<T> _head;
        private IComparer<T> _comparer;

        public int Count { get; private set; }

        public BinarySearchTree(IComparer<T> comparer = null)
        {
            _comparer = comparer ?? (Comparer<T>.Default ?? throw new ArgumentNullException("Comparer's indefined for type of T!"));
        }

        public BinarySearchTree(T value, IComparer<T> comparer = null) : this (comparer)
        {
            _head = new Node<T>
            {
                Data = value
            };

            Count++;
        }
        
        public void Add(T value)
        {
            //if (_head == null)
            //{
            //    _head = new Node<T>
            //    {
            //        Data = value
            //    };
            //}
            //else
            //{
            //    InsertValue(_head, value);
            //}

            // create a new Node instance
            var n = new Node<T>()
            {
                Data = value
            };

            int result;
            
            Node<T> current = _head, parent = null;
            while (current != null)
            {
                result = _comparer.Compare(current.Data, value);
                if (result == 0)
                    return;
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
            if (parent == null)
                _head = n;
            else
            {
                result = _comparer.Compare(parent.Data, value);
                if (result > 0)
                    parent.Left = n;
                else
                    parent.Right = n;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return Preorder().GetEnumerator();
        }
        
        public IEnumerable<T> Preorder()
        {
            if (_head == null)
            {
                throw new InvalidOperationException($"Object of {nameof(BinarySearchTree<T>)} haven't any element!");
            }

            return GetValuePreorder(_head);
        }

        
        public IEnumerable<T> Inorder()
        {
            if (_head == null)
            {
                throw new InvalidOperationException($"Object of {nameof(BinarySearchTree<T>)} haven't any element!");
            }

            return GetValueInorder(_head);
        }
        
        public IEnumerable<T> Postorder()
        {
            if (_head == null)
            {
                throw new InvalidOperationException($"Object of {nameof(BinarySearchTree<T>)} haven't any element!");
            }

            return GetValuePostorder(_head);
        }

        // delete finding node
        // insert his value in tree
        public void Remove(T value)
        {
            throw new NotImplementedException();
        }

        #region Private method
        private Node<T> InsertValue(Node<T> node, T value)
        {
            if (node == null)
            {
                node = new Node<T>
                {
                    Data = value
                };

                return node;
            }
            else
            {
                if (_comparer.Compare(node.Data, value) < 0)
                {
                    node.Right = InsertValue(node.Right, value);

                    return node.Right;
                }
                else
                {
                    node.Left = InsertValue(node.Left, value);

                    return node.Left;
                }
            }
        }

        // root, left child, right child
        private IEnumerable<T> GetValuePreorder(Node<T> node)
        {
            if (node != null)
            {
                yield return node.Data;

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

                yield return node.Data;

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

                yield return node.Data;
            }
        }
        #endregion
    }
}
