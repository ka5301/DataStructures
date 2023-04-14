using DSImplementations.AppCode.Interfaces;
using System;
using System.Diagnostics;

namespace AppCode.SortingAlgos
{
    internal static class Queue<T, U> where T : IStack<U>, new() where U : IComparable<U>
    {
        internal static void BubbleSort(T stack, out TimeSpan timeTaken)
        {
            Stopwatch sw = Stopwatch.StartNew();

            T tempStack = new T();
            int n = stack.Count;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    U a = stack.Pop();
                    U b = stack.Pop();

                    if (a.CompareTo(b) < 0)
                    {
                        tempStack.Push(a);
                        stack.Push(b);
                    }
                    else
                    {
                        tempStack.Push(b);
                        stack.Push(a);
                    }
                }
                while (tempStack.Count > 0)
                {
                    stack.Push(tempStack.Pop());
                }
            }
            sw.Stop();
            timeTaken = sw.Elapsed;
        }
        internal static void InsertionSort(T stack , out TimeSpan timeTaken)
        {
            Stopwatch sw = Stopwatch.StartNew();

            if (stack == null || stack.Count < 2)
            {
                sw.Stop();
                timeTaken = sw.Elapsed;
                return;
            }

            T tempStack = new T();
            while (stack.Count > 0)
            {
                U temp = stack.Pop();
                while (tempStack.Count > 0 && tempStack.Top().CompareTo(temp) > 0)
                {
                    stack.Push(tempStack.Pop());
                }
                tempStack.Push(temp);
            }

            while (tempStack.Count > 0)
            {
                stack.Push(tempStack.Pop());
            }

            sw.Stop();
            timeTaken = sw.Elapsed;
        }
        internal static void SelectionSort(T stack, out TimeSpan timeTaken)
        {
            Stopwatch sw = Stopwatch.StartNew();

            T tempStack = new T();
            int n = stack.Count;
            for (int i = 0; i < n - 1; i++)
            {
                U min = stack.Pop();
                for (int j = i + 1; j < n; j++)
                {
                    U curr = stack.Pop();
                    if (curr.CompareTo(min)>0)
                    {
                        tempStack.Push(min);
                        min = curr;
                    }
                    else
                    {
                        tempStack.Push(curr);
                    }
                }
                stack.Push(min);
                while (tempStack.Count > 0)
                {
                    stack.Push(tempStack.Pop());
                }
            }
            sw.Stop();
            timeTaken = sw.Elapsed;
        }

        private static T Merge(T left, T right)
        {
            T mergedStack = new T();

            while (left.Count > 0 && right.Count > 0)
            {
                if (left.Top().CompareTo(right.Top()) < 0)
                {
                    mergedStack.Push(left.Pop());
                }
                else
                {
                    mergedStack.Push(right.Pop());
                }
            }

            while (left.Count > 0)
            {
                mergedStack.Push(left.Pop());
            }

            while (right.Count > 0)
            {
                mergedStack.Push(right.Pop());
            }

            // Reverse the order to get the elements in ascending order
            T sortedStack = new T();
            while (mergedStack.Count > 0)
            {
                sortedStack.Push(mergedStack.Pop());
            }

            return sortedStack;
        }
        private static T MergeSort(T stack)
        {
            if (stack.Count <= 1)
            {
                return stack;
            }

            T left = new T();
            T right = new T();
            int middle = stack.Count / 2;

            // Divide the stack into two halves
            for (int i = 0; i < middle; i++)
            {
                left.Push(stack.Pop());
            }

            while (stack.Count > 0)
            {
                right.Push(stack.Pop());
            }

            // Recursively sort the two halves
            left = MergeSort(left);
            right = MergeSort(right);

            // Merge the two sorted halves
            return Merge(left, right);
        }
        internal static void MergeSort(T stack, out TimeSpan timeTaken)
        {
            Stopwatch sw = Stopwatch.StartNew();
            stack = MergeSort(stack);
            sw.Stop();
            timeTaken = sw.Elapsed;
        }

        private static T QuickSort(T stack)
        {
            if (stack.Count <= 1)
            {
                return stack;
            }

            U pivot = stack.Pop();
            T left = new T();
            T right = new T();

            while (stack.Count > 0)
            {
                U current = stack.Pop();
                if (current.CompareTo(pivot) < 0)
                {
                    left.Push(current);
                }
                else
                {
                    right.Push(current);
                }
            }

            left = QuickSort(left);
            right = QuickSort(right);

            T mergedStack = new T();
            while (right.Count > 0)
            {
                mergedStack.Push(right.Pop());
            }
            mergedStack.Push(pivot);
            while (left.Count > 0)
            {
                mergedStack.Push(left.Pop());
            }

            T sortedStack = new T();
            while (mergedStack.Count > 0)
            {
                sortedStack.Push(mergedStack.Pop());
            }

            return sortedStack;
        }
        internal static void QuickSort(T stack, out TimeSpan timeTaken)
        {
            Stopwatch sw = Stopwatch.StartNew();
            stack = QuickSort(stack);
            sw.Stop();
            timeTaken = sw.Elapsed;
        }
    }
}
