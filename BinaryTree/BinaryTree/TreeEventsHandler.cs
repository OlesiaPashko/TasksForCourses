using System;
using System.Collections.Generic;
using System.Text;

namespace BinaryTree
{
    public class TreeEventsHandler<T> where T : IComparable<T>
    {
        public static void AddElement(object sender, ActionWithNodeEventArgs<T> e)
        {
            string TreeInfo = sender.ToString();
            string nodeInfo = e.NodeData.ToString();
            Console.WriteLine($"ELEMENT {nodeInfo}\n =========was added to tree======= \n{TreeInfo}");
        }

        public static void RemoveElement(object sender, ActionWithNodeEventArgs<T> e)
        {
            Console.WriteLine($"ELEMENT {e.NodeData.ToString()}\n ============was removed from tree=========== \n {sender.ToString()}");
        }
    }
}
