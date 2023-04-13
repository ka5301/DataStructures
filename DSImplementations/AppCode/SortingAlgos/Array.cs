using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCode.SortingAlgos
{
    internal static class Array<T> where T : IComparable<T>
    {
        private static void Swap(T[] array, int i, int j)
        {
            T temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }
        public static void BubbleSort(T[] array, out TimeSpan timeTaken)
        {
            int n = array.Length;
            Stopwatch sw = Stopwatch.StartNew();

            bool flag = true;
            for (int i = 0; (i < n) && flag; i++)
            {
                flag = false;
                for (int j = 0; (j < n - i - 1); j++)
                {
                    if (array[j].CompareTo(array[j + 1]) > 0)
                    {
                        Swap(array, i, j);
                        flag = true;
                    }
                }
            }

            sw.Stop();
            timeTaken = sw.Elapsed;
        }
        public static void SelectionSort(T[] array, out TimeSpan timeTaken)
        {
            int n = array.Length;
            Stopwatch sw = Stopwatch.StartNew();

            int smallest;
            for (int i = 0; i < n - 1; i++)
            {
                smallest = i;
                for (int j = i + 1; j < n; j++)
                {
                    if (array[j].CompareTo(array[smallest]) < 0)
                    {
                        smallest = j;
                    }
                }
                Swap(array, i, smallest);
            }

            sw.Stop();
            timeTaken = sw.Elapsed;
        }
        public static void InsertionSort(T[] array, out TimeSpan timeTaken)
        {
            int n = array.Length;
            Stopwatch sw = Stopwatch.StartNew();

            for (int i = 0; i < n; i++)
            {
                var key = array[i];
                int j = i - 1;
                while (j >= 0 && array[j].CompareTo(key) > 0)
                {
                    array[j + 1] = array[j];
                    j--;
                }
                array[j + 1] = key;
            }

            sw.Stop();
            timeTaken = sw.Elapsed;
        }

        private static void Merge(T[] array, int l, int m, int r)
        {
            int i, j, k;
            int n1 = m - l + 1;
            int n2 = r - m;

            T[] L = new T[n1], R = new T[n2];

            for (i = 0; i < n1; i++)
                L[i] = array[l + i];
            for (j = 0; j < n2; j++)
                R[j] = array[m + 1 + j];

            i = 0;
            j = 0;
            k = l;
            while (i < n1 && j < n2)
            {
                if (L[i].CompareTo(R[j]) <= 0)
                {
                    array[k] = L[i];
                    i++;
                }
                else
                {
                    array[k] = R[j];
                    j++;
                }
                k++;
            }

            while (i < n1)
            {
                array[k] = L[i];
                i++;
                k++;
            }

            while (j < n2)
            {
                array[k] = R[j];
                j++;
                k++;
            }
        }
        private static void MergeSort(T[] array, int l, int r)
        {
            if (l < r)
            {
                int m = l + (r - l) / 2;
                MergeSort(array, l, m);
                MergeSort(array, m + 1, r);

                Merge(array, l, m, r);
            }
        }
        public static void MergeSort(T[] array, out TimeSpan timeTaken)
        {
            int n = array.Length;
            Stopwatch sw = Stopwatch.StartNew();

            MergeSort(array, 0, n - 1);

            sw.Stop();
            timeTaken = sw.Elapsed;
        }

        private static int Partition(T[] array, int low, int high)
        {
            var pivot = array[high];
            int i = (low - 1);

            for (int j = low; j <= high - 1; j++)
            {
                if (array[j].CompareTo(pivot) < 0)
                {
                    i++;
                    Swap(array, i, j);
                }
            }
            Swap(array, i + 1, high);
            return (i + 1);
        }
        private static void QuickSort(T[] array, int low, int high)
        {
            if (low < high)
            {
                int pi = Partition(array, low, high);
                QuickSort(array, low, pi - 1);
                QuickSort(array, pi + 1, high);
            }
        }
        public static void QuickSort(T[] array, out TimeSpan timeTaken)
        {
            int n = array.Length;
            Stopwatch sw = Stopwatch.StartNew();

            QuickSort(array, 0, n - 1);

            sw.Stop();
            timeTaken = sw.Elapsed;
        }
    }
}
