﻿namespace Task1.Logic
{
    /// <summary>
    /// Node for binary tree
    /// </summary>
    /// <typeparam name="T"> Type of saving data </typeparam>
    public sealed class Node<T>
    {
        /// <summary>
        /// Data
        /// </summary>
        public T Value { get; set; }

        /// <summary>
        /// Left child
        /// </summary>
        public Node<T> Left { get; set; }

        /// <summary>
        /// Right child
        /// </summary>
        public Node<T> Right { get; set; }
    }
}
