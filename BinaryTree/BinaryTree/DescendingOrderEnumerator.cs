using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace BinaryTree
{
    public class DescendingOrderEnumerator<T> : IEnumerator<T>
       where T : IComparable<T>
    {
        private BinaryTreeNode<T> root;

        private int count = 0;
        object IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }
        private int curIndex;
        private BinaryTreeNode<T>[] array;

        public T Current
        {
            get
            {
                if (curIndex == -1)
                {
                    return default(T);
                }
                return array[curIndex].Data;
            }
        }

        public DescendingOrderEnumerator(BinaryTreeNode<T> root)
        {
            this.root = root;
            curIndex = -1;
            CountNodes(root);
            array = new BinaryTreeNode<T>[count];
            if (root != null)
            {
                MakeArrayFromTree(root, -1);
            }
        }

        private int MakeArrayFromTree(BinaryTreeNode<T> curNode, int ind)
        {
            if (curNode == null)
            {
                return ind;
            }

            if (curNode.RightNode != null)
            {
                ind = MakeArrayFromTree(curNode.RightNode, ind);
            }

            array[++ind] = curNode;

            if (curNode.LeftNode != null)
            {
                ind = MakeArrayFromTree(curNode.LeftNode, ind);
            }


            return ind;
        }

        private void CountNodes(BinaryTreeNode<T> curNode)
        {
            if (curNode == null)
            {
                return;
            }

            if (curNode.LeftNode != null)
            {
                CountNodes(curNode.LeftNode);
            }

            count++;

            if (curNode.RightNode != null)
            {
                CountNodes(curNode.RightNode);
            }

            return;
        }


        public void Dispose() { }


        public bool MoveNext()
        {
            curIndex++;
            return curIndex < array.Length;
        }


        public void Reset()
        {
            curIndex = -1;
        }
    }

}

