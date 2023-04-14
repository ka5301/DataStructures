using DSImplementations.AppCode.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AppCode.DataStructures
{
    internal class LinkedList<T> where T : IComparable<T>
    {
        internal class Node : INode<T, Node>
        {
            internal T Value { get; set; }
            internal Node Next { get; set; }
            
            T INode<T, Node>.Value { get => Value; set => Value = value; }
            Node INode<T, Node>.Next { get => Next; set => Next = value; }
            
            internal Node(T value)
            {
                Value = value;
                Next = null;
            }

        }
        
        internal Node Head { get; set; }
        internal Node Tail { get; set; }
        internal int Count { get; private set; } 
        
        public LinkedList(T value)
        {
            Head = new Node(value);
            Tail = Head;
            Count = 1;
        }
        public LinkedList(IEnumerable<T> data)
        {
            foreach (var item in data)
            {
                Insert(item);
            }
        }

        internal void Insert(T data)
        {
            if(Head == null)
            {
                Head = new Node(data);
                Tail = Head;
                Count = 1;
            }

            else
            {
                Tail.Next = new Node(data);
                Tail = Tail.Next;
                Count++;
            }
        }
        
        internal void Print()
        {
            Node node = Head;
            while (node != null)
            {
                Console.WriteLine(node.Value.ToString());
                node = node.Next;
            }
        }
        
        
    }
}
