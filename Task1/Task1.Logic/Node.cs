using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.Logic
{
    public sealed class Node<T>
    {
        public T data { get; set; }

        public Node<T> Left { get; set; }

        public Node<T> Right { get; set; }
    }
}
