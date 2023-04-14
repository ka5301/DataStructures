using DSImplementations.AppCode.Interfaces;
using System;
using System.Diagnostics;

namespace DSImplementations.AppCode.SortingAlgos
{
    internal class Queue<T, U> where T : IQueue<U>, new() where U : IComparable<U>
    {
        internal static void BubbleSort(T queue, out TimeSpan timeTaken)
        {
            Stopwatch sw = Stopwatch.StartNew();
            int n = queue.Count;
            U[] tempArray = new U[n];

            for (int i = 0; i < n; i++)
            {
                tempArray[i] = queue.Dequeue();
            }

            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (tempArray[j].CompareTo(tempArray[j + 1]) > 0)
                    {
                        U temp = tempArray[j];
                        tempArray[j] = tempArray[j + 1];
                        tempArray[j + 1] = temp;
                    }
                }
            }

            for (int i = 0; i < n; i++)
            {
                queue.Enqueue(tempArray[i]);
            }

            sw.Stop();
            timeTaken = sw.Elapsed;
        }
        internal static void InsertionSort(T queue, out TimeSpan timeTaken)
        {
            Stopwatch sw = Stopwatch.StartNew();
            int n = queue.Count;
            U[] tempArray = new U[n];
            for (int i = 0; i < n; i++)
            {
                tempArray[i] = queue.Dequeue();
            }

            for (int i = 1; i < n; i++)
            {
                U key = tempArray[i];
                int j = i - 1;

                while (j >= 0 && tempArray[j].CompareTo(key)>0)
                {
                    tempArray[j + 1] = tempArray[j];
                    j--;
                }

                tempArray[j + 1] = key;
            }
            for (int i = 0; i < n; i++)
            {
                queue.Enqueue(tempArray[i]);
            }
            sw.Stop();
            timeTaken = sw.Elapsed;
        }
        internal static void SelectionSort(T queue, out TimeSpan timeTaken)
        {
            Stopwatch sw = Stopwatch.StartNew();
            int n = queue.Count;
            for (int i = 0; i < n - 1; i++)
            {
                int minIndex = i;
                U minValue = queue.Dequeue();

                for (int j = i + 1; j < n; j++)
                {
                    U currValue = queue.Dequeue();
                    if (currValue.CompareTo(minValue) < 0)
                    {
                        minIndex = j;
                        minValue = currValue;
                    }
                    queue.Enqueue(currValue);
                }
                for (int k = i; k < minIndex; k++)
                {
                    U tempValue = queue.Dequeue();
                    queue.Enqueue(tempValue);
                }
                queue.Enqueue(minValue);
            }


            sw.Stop();
            timeTaken = sw.Elapsed;
        }
        
        private static T MergeSort(T queue)
        {
            if (queue.Count <= 1)
            {
                return queue;
            }

            T left = new T();
            T right = new T();
            int middle = queue.Count / 2;

            for (int i = 0; i < middle; i++)
            {
                left.Enqueue(queue.Dequeue());
            }

            while (queue.Count > 0)
            {
                right.Enqueue(queue.Dequeue());
            }

            left = MergeSort(left);
            right = MergeSort(right);

            return Merge(left, right);
        }
        private static T Merge(T left, T right)
        {
            T result = new T();

            while (left.Count > 0 && right.Count > 0)
            {
                if (left.Peek().CompareTo(right.Peek()) < 0)
                {
                    result.Enqueue(left.Dequeue());
                }
                else
                {
                    result.Enqueue(right.Dequeue());
                }
            }

            while (left.Count > 0)
            {
                result.Enqueue(left.Dequeue());
            }

            while (right.Count > 0)
            {
                result.Enqueue(right.Dequeue());
            }

            return result;
        }
        public static void MergeSort(T queue, out TimeSpan timeTaken)
        {
            Stopwatch sw = Stopwatch.StartNew();
            queue = MergeSort(queue);
            sw.Stop();
            timeTaken = sw.Elapsed;
        }

        private static T QuickSort(T queue)
        {
            if (queue.Count <= 1)
            {
                return queue;
            }

            U pivot = queue.Dequeue();
            T left = new T();
            T right = new T();

            while (queue.Count > 0)
            {
                U current = queue.Dequeue();
                if (current.CompareTo(pivot) < 0)
                {
                    left.Enqueue(current);
                }
                else
                {
                    right.Enqueue(current);
                }
            }

            left = QuickSort(left);
            right = QuickSort(right);

            T sortedQueue = new T();
            while (left.Count > 0)
            {
                sortedQueue.Enqueue(left.Dequeue());
            }
            sortedQueue.Enqueue(pivot);
            while (right.Count > 0)
            {
                sortedQueue.Enqueue(right.Dequeue());
            }

            return sortedQueue;
        }
        internal static void QuickSort(T queue, out TimeSpan timeTaken)
        {
            Stopwatch sw = Stopwatch.StartNew();
            queue = QuickSort(queue);
            sw.Stop();
            timeTaken = sw.Elapsed;
        }
    }
}
