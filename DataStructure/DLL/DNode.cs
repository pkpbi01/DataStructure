using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructure.DLinkedList
{
    public class DNode
    {
        public int Value { get; set; }

        public DNode Next { get; set; }

        public DNode Previous { get; set; }

        public DNode(int value)
        {
            Value = value;
            Next = null;
            Previous = null;
        }

        public DNode(DNode dNode)
        {
            Next = dNode.Next;
            Previous = dNode.Previous;
            Value = dNode.Value;

        }

        public DNode()
        {
        }
    }
}
