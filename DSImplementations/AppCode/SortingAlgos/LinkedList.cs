using AppCode.Interfaces;
using DSImplementations.AppCode.Interfaces;
using System;
using System.Diagnostics;

namespace AppCode.SortingAlgos
{
    internal static class LinkedList<T,U> where T : IComparable<T> where U : class, INode<T,U>
    {
        private static void Swap(U a, U b)
        {
            T tmp = b.Value;
            b.Value = a.Value;
            a.Value = tmp;
        }

        internal static void BubbleSort(U Head,out TimeSpan timeTaken)
        {
            Stopwatch sw = Stopwatch.StartNew();

            U start = Head;
            int swapped;

            U ptr1;
            U lptr = null;

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

                if(ptr1 != lptr)

                while (ptr1.Next != lptr) 
                {
                    if ((ptr1.Value.CompareTo(ptr1.Next.Value) > 0))
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
        internal static void SelectionSort(U Head, out TimeSpan timeTaken)
        {
            Stopwatch sw = Stopwatch.StartNew();

            U temp = Head;

            while (temp != null)
            {
                U min = temp;
                U r = temp.Next;

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
        internal static void InsertionSort(U Head, out TimeSpan timeTaken)
        {
            Stopwatch sw = Stopwatch.StartNew();

            U sorted = null, current = Head;

            while (current != null)
            {
                U temp = current.Next;
                if (sorted == null || sorted.Value.CompareTo(current.Value) >= 0)
                {
                    current.Next = sorted;
                    sorted = current;
                }
                else
                {
                    U sCurrent = sorted;
                    while (sCurrent.Next != null && sCurrent.Next.Value.CompareTo(current.Value) < 0)
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

        private static U Merge(U a, U b)
        {
            U result = null, temp = null;

            while (a != null && b != null)
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

            while (a != null)
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
        private static U MergeSort(U head)
        {
            if (head == null || head.Next == null)
            {
                return head;
            }

            U middle = GetMiddle(head);
            U nextOfMiddle = middle.Next;

            middle.Next = null;

            U left = MergeSort(head);
            U right = MergeSort(nextOfMiddle);

            U sortedList = Merge(left, right);
            return sortedList;
        }
        private static U GetMiddle(U head)
        {
            if (head == null)
                return head;
            U fastMove = head.Next;
            U slowMove = head;

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
        internal static void MergeSort(U Head, out TimeSpan timeTaken)
        {
            Stopwatch sw = Stopwatch.StartNew();

            Head = MergeSort(Head);

            sw.Stop();
            timeTaken = sw.Elapsed;

            //Print();
        }

        private static U PartitionLast(U start, U end)
        {
            if (start == end || start == null || end == null)
                return start;

            U pivot_prev = start;
            U curr = start;
            var pivot = end.Value;

            dynamic temp;
            while (start != end)
            {

                if (start.Value.CompareTo(pivot) < 0)
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
        private static void QuickSort(U start, U end)
        {
            if (start == end)
                return;

            U pivot_prev = PartitionLast(start, end);
            QuickSort(start, pivot_prev);

            if (pivot_prev != null && pivot_prev == start)
                QuickSort(pivot_prev.Next, end);

            else if (pivot_prev != null && pivot_prev.Next != null)
                QuickSort(pivot_prev.Next.Next, end);
        }
        internal static void QuickSort(U Head, U Tail, out TimeSpan timeTaken)
        {
            Stopwatch sw = Stopwatch.StartNew();

            QuickSort(Head, Tail);

            sw.Stop();
            timeTaken = sw.Elapsed;

            //Print();
        }
    }
}
