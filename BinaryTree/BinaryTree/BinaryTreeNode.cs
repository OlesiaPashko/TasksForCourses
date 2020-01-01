using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace BinaryTree
{
    public class BinaryTreeNode<T> where T : IComparable<T>
    {
        public T Data { get; set; }

        public BinaryTreeNode<T> LeftNode { get; set; } = null;

        public BinaryTreeNode<T> RightNode { get; set; } = null;

        public BinaryTreeNode<T> ParentNode { get; set; } = null;

        public BinaryTreeNode(T data)
        {
            this.Data = data;
        }

        public override string ToString() => Data.ToString();

        public void Add(T elem)
        {
            if (elem == null)
                throw new NullReferenceException("Can not add null as tree element");
            if (elem.CompareTo(Data) == 1)
            {
                if (RightNode == null)
                {
                    RightNode = new BinaryTreeNode<T>(elem);
                    RightNode.ParentNode = this;
                    return;
                }
                RightNode.Add(elem);
                return;
            }

            if (LeftNode == null)
            {
                LeftNode = new BinaryTreeNode<T>(elem);
                LeftNode.ParentNode = this;
                return;
            }
            LeftNode.Add(elem);
            return;
        }

        public void Remove(T elem)
        {
            if (elem == null)
                throw new NullReferenceException("Can not remove null as tree element");
            if (Data.Equals(elem))
            {
                if (LeftNode == null && RightNode == null)
                {
                    if (ParentNode == null)
                        return;
                    if (ParentNode.Data.CompareTo(elem) == -1)
                    {
                        ParentNode.RightNode = null;
                        return;
                    }
                    ParentNode.LeftNode = null;
                    return;
                }
                if (RightNode == null)
                {
                    LeftNode.ParentNode = this.ParentNode;
                    this.Data = LeftNode.Data;
                    this.RightNode = LeftNode.RightNode;
                    this.LeftNode = LeftNode.LeftNode;
                    return;
                }
                if (LeftNode == null)
                {
                    RightNode.ParentNode = this.ParentNode;
                    this.Data = RightNode.Data;
                    this.LeftNode = RightNode.LeftNode;
                    this.RightNode = RightNode.RightNode;
                    return;
                }
                LeftNode.BoundToRight(RightNode);
                LeftNode.ParentNode = this.ParentNode;
                this.Data = LeftNode.Data;
                this.RightNode = LeftNode.RightNode;
                this.LeftNode = LeftNode.LeftNode;
                return;
            }

            if (elem.CompareTo(this.Data) == -1)
            {
                if (LeftNode != null)
                    LeftNode.Remove(elem);
                return;
            }


            if (RightNode != null)
                RightNode.Remove(elem);
            return;
        }

        private void BoundToRight(BinaryTreeNode<T> node)
        {
            if (node == null)
            {
                throw new ArgumentNullException("Cannot bound with null");
            }
            if (RightNode == null)
            {
                node.ParentNode = this;
                RightNode = node;
                return;
            }
            RightNode.BoundToRight(node);
        }

        public bool Find(T elem)
        {
            if (elem == null)
            {
                throw new NullReferenceException("Value cannot be null.");
            }

            if (this.Data.Equals(elem))
            {
                return true;
            }

            if (elem.CompareTo(Data) == -1)
            {
                return LeftNode != null && LeftNode.Find(elem);
            }

            return RightNode != null && RightNode.Find(elem);
        }

        public override bool Equals(object obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            BinaryTreeNode<T> node = (BinaryTreeNode<T>) obj;
            return Data.Equals(node.Data);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

    }
}

