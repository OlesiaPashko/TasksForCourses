using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace BinaryTree
{
    public class BinaryTree<T> : IEnumerable<T> where T : IComparable<T>
    {
        public BinaryTreeNode<T> Root { get; set; }

        public delegate void TreeEventHandler(object sender, ActionWithNodeEventArgs<T> e);

        public event TreeEventHandler AddNodeEvent;

        public event TreeEventHandler RemoveNodeEvent;

        public BinaryTree(T root)
        {
            this.Root = new BinaryTreeNode<T>(root);
        }

        public BinaryTree()
        {
            Root = null;
        }

        public void Add(T elem)
        {
            if (Root == null)
                this.Root = new BinaryTreeNode<T>(elem);
            else
            {
                Root.Add(elem);
            }
            AddNodeEvent?.Invoke(this, new ActionWithNodeEventArgs<T>(elem));
        }

        public void Remove(T elem)
        {
            if (Root == null)
            {
                throw new NullReferenceException("Can not remove from empty tree");
            }
            Root.Remove(elem);
            RemoveNodeEvent?.Invoke(this, new ActionWithNodeEventArgs<T>(elem));
        }

        public bool Find(T elem)
        {
            if (elem == null)
            {
                throw new NullReferenceException("Can not take null as argument to find");
            }

            return Root.Find(elem);
        }
        public IEnumerator<T> GetEnumerator()
        {
            if (Root == null)
                throw new NullReferenceException("Can not GetEnumerator of empty tree");
            return new AscendingOrderEnumerator<T>(Root);
        }

        public IEnumerator<T> GetDescendingEnumerator()
        {
            if (Root == null)
                throw new NullReferenceException("Can not GetEnumerator of empty tree");
            return new DescendingOrderEnumerator<T>(Root);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            foreach (T elem in this)
            {
                result.Append($"NODE: {elem.ToString()}\n");
            }
            return result.ToString();
        }

        public string ToStringDescending()
        {
            StringBuilder result = new StringBuilder();
            IEnumerator<T> enumerator = this.GetDescendingEnumerator();
            while (enumerator.MoveNext())
            {
                result.Append($"NODE: {enumerator.Current.ToString()}\n");
            }
            return result.ToString();
        }
    }
}
