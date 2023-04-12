using Microsoft.Office.Interop.Excel;
using Remotion.Globalization;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace DSImplementations.AppCode.DataStructures
{
    internal class Node<T> where T : IComparable<T>
    {
        internal T Value { get; set; }
        internal Node<T> Next { get; set; }

        internal Node(T value)
        {
            this.Value = value;
            this.Next = null;
        }

    }
    internal class LinkList<T> where T : IComparable<T>
    {
        internal Node<T> Head { get; set; }

        internal int Count { get; private set; } 


        private Node<T> Tail { get; set; }

        internal LinkList(T value)
        {
            Head = new Node<T>(value);
            Tail = Head;
            Count = 1;
        }
        internal LinkList(IQueryable<T> data)
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
                Head = new Node<T>(data);
                Tail = Head;
                Count = 1;
            }

            else
            {
                Tail.Next = new Node<T>(data);
                Tail = Tail.Next;
                Count++;
            }
        }

        private void Swap(Node<T> a, Node<T> b)
        {
            var tmp = b.Value;
            b.Value = a.Value;
            a.Value = tmp;
        }

        internal void Print()
        {
            Node<T> node = Head;
            while (node != null)
            {
                Console.WriteLine(node.Value.ToString());
                node = node.Next;
            }
        }

        internal void BubbleSort(out TimeSpan timeTaken)
        {
            Stopwatch sw = Stopwatch.StartNew();

            Node<T> start = Head;
            int swapped;

            Node<T> ptr1; 
            Node<T> lptr = null; 

            if (start == null)
            {
                sw.Stop();
                timeTaken = sw.Elapsed;
                return;
            }
  
            do
            { 
                swapped = 0; 
                ptr1 = start; 
  
                while (ptr1.Next != lptr) 
                { 
                    if ((ptr1.Value.CompareTo(ptr1.Next.Value)>0)) 
                    { 
                        Swap(ptr1, ptr1.Next);
                        swapped = 1; 
                    }
                    ptr1 = ptr1.Next; 
                }
                lptr = ptr1; 
            } 
            while (swapped != 0);
            
            sw.Stop();
            timeTaken = sw.Elapsed;

            //Print();
        }
        internal void SelectionSort(out TimeSpan timeTaken)
        {
            Stopwatch sw = Stopwatch.StartNew();

            Node<T> temp = Head;

            while (temp != null)
            {
                Node<T> min = temp;
                Node<T> r = temp.Next;

                while (r != null)
                {
                    if ((min.Value.CompareTo(r.Value) > 0))
                        min = r;
                    r = r.Next;
                }
                Swap(temp, min);
                temp = temp.Next;
            }

            sw.Stop();
            timeTaken = sw.Elapsed;

            //Print();
        }
        internal void InsertionSort(out TimeSpan timeTaken)
        {
            Stopwatch sw = Stopwatch.StartNew();

            Node<T> sorted = null,current = Head;

            while(current != null)
            {
                Node<T> temp = current.Next;
                if(sorted == null || sorted.Value.CompareTo(current.Value) >= 0){
                    current.Next = sorted;
                    sorted = current;
                }
                else
                {
                    Node<T> sCurrent = sorted;
                    while(sCurrent.Next != null && sCurrent.Next.Value.CompareTo(current.Value) < 0)
                    {
                        sCurrent = sCurrent.Next;
                    }
                    current.Next = sCurrent.Next;
                    sCurrent.Next = current;
                }
                current = temp;
            }

            Head = sorted;
            sw.Stop();
            timeTaken = sw.Elapsed;

            //Print();
        }

        private Node<T> Merge(Node<T> a, Node<T> b)
        {
            Node<T> result = null, temp = null;

            while(a!=null && b!= null)
            {
                if (a.Value.CompareTo(b.Value) <= 0)
                {
                    if (result == null)
                    {
                        result = a;
                        temp = a;
                    }
                    else
                    {
                        temp.Next = a;
                        temp = temp.Next;
                    }
                    a = a.Next;
                }
                else
                {
                    if (result == null)
                    {
                        result = b;
                        temp = b;
                    }
                    else
                    {
                        temp.Next = b;
                        temp = temp.Next;
                    }
                    b = b.Next; 
                }
            }

            while(a != null)
            {
                temp.Next = a;
                temp = temp.Next;
                a = a.Next;
            }

            while (b != null)
            {
                temp.Next = b;
                temp = temp.Next;
                b = b.Next;
            }

            return result;
        }
        private Node<T> MergeSort(Node<T> head)
        {
            if (head == null || head.Next == null)
            {
                return head;
            }

            Node<T> middle = GetMiddle(head);
            Node<T> nextOfMiddle = middle.Next;

            middle.Next = null;

            Node<T> left = MergeSort(head);
            Node<T> right = MergeSort(nextOfMiddle);

            Node<T> sortedList = Merge(left, right);
            return sortedList;
        }
        private Node<T> GetMiddle(Node<T> head)
        {
            if (head == null)
                return head;
            Node<T> fastMove = head.Next;
            Node<T> slowMove = head;

            while (fastMove != null)
            {
                fastMove = fastMove.Next;
                if (fastMove != null)
                {
                    slowMove = slowMove.Next;
                    fastMove = fastMove.Next;
                }
            }
            return slowMove;
        }
        internal void MergeSort(out TimeSpan timeTaken)
        {
            Stopwatch sw = Stopwatch.StartNew();

            Head = MergeSort(Head);

            sw.Stop();
            timeTaken = sw.Elapsed;

            //Print();
        }


        private Node<T> PartitionLast(Node<T> start, Node<T> end)
        {
            if (start == end || start == null || end == null)
                return start;

            Node<T> pivot_prev = start;
            Node<T> curr = start;
            var pivot = end.Value;

            dynamic temp;
            while (start != end)
            {

                if (start.Value.CompareTo(pivot)<0)
                {
                    pivot_prev = curr;

                    temp = curr.Value;
                    curr.Value = start.Value;
                    start.Value = temp;

                    curr = curr.Next;
                }
                start = start.Next;
            }

            temp = curr.Value;
            curr.Value = pivot;
            end.Value = temp;

            return pivot_prev;
        }
        private void QuickSort(Node<T> start, Node<T> end)
        {
            if (start == end)
                return;

            Node<T> pivot_prev = PartitionLast(start, end);
            QuickSort(start, pivot_prev);

            if (pivot_prev != null && pivot_prev == start)
                QuickSort(pivot_prev.Next, end);

            else if (pivot_prev != null && pivot_prev.Next != null)
                QuickSort(pivot_prev.Next.Next, end);
        }
        internal void QuickSort(out TimeSpan timeTaken)
        {
            Stopwatch sw = Stopwatch.StartNew();

            QuickSort(Head,Tail);

            sw.Stop();
            timeTaken = sw.Elapsed;

            //Print();
        }
    }
}
