using DSImplementations.AppCode.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCode.DataStructures
{
    internal class DoublyLinkedList<T> where T : IComparable<T>
    {
        internal class Node : INode<T, Node>
        {
            internal T Value { get; set; }
            internal Node Next { get; set; }
            internal Node Prev { get; set; }

            T INode<T, Node>.Value { get => Value; set => Value = value; }
            Node INode<T, Node>.Next { get => Next; set => Next = value; }

            internal Node(T value)
            {
                this.Value = value;
                this.Next = null;
                this.Prev = null;
            }

        }
        internal Node Head { get; set; }
        internal int Count { get; private set; }
        internal Node Tail { get; set; }

        internal DoublyLinkedList(T value)
        {
            Head = new Node(value);
            Tail = Head;
            Count = 1;
        }
        internal DoublyLinkedList(IQueryable<T> data)
        {
            foreach (var item in data)
            {
                InsertEnd(item);
            }
        }

        internal void InsertFront(T data)
        {
            if (Head == null)
            {
                Head = new Node(data);
                Tail = Head;
                Count = 1;
            }

            else
            {
                Node newNode = new Node(data);
                newNode.Next = Head;
                Head.Prev = newNode;
                Head = Head.Prev;
                Count++;
            }
        }
        internal void InsertEnd(T data)
        {
            if (Head == null)
            {
                Head = new Node(data);
                Tail = Head;
                Count = 1;
            }

            else
            {
                Node newNode = new Node(data);
                newNode.Prev = Tail;
                Tail.Next = newNode;
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
