using System;
using System.Collections.Generic;
using System.Text;

namespace BinaryTree
{
    public class ActionWithNodeEventArgs<T> : EventArgs where T : IComparable<T>
    {
        public T NodeData { get; set; }

        public ActionWithNodeEventArgs(T elem)
        {
            this.NodeData = elem;
        }
    }
}
