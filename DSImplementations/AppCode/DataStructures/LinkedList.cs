using DSImplementations.AppCode.Interfaces;
using Microsoft.Office.Interop.Excel;
using Remotion.Globalization;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

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
            
            //Node INode<T, Node>.Prev { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }


            internal Node(T value)
            {
                this.Value = value;
                this.Next = null;
            }

        }
        internal Node Head { get; set; }
        internal int Count { get; private set; } 
        internal Node Tail { get; set; }

        internal LinkedList(T value)
        {
            Head = new Node(value);
            Tail = Head;
            Count = 1;
        }
        internal LinkedList(IQueryable<T> data)
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
