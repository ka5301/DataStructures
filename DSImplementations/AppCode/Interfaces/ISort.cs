using System;

namespace AppCode.Interfaces
{
    internal interface ISort<T>
    {
        void BubbleSort(T obj,out TimeSpan timeTaken);
        void SelectionSort(T obj,out TimeSpan timeTaken);
        void InsertionSort(T obj, out TimeSpan timeTaken);
        void MergeSort(T obj, out TimeSpan timeTaken);
        void QuickSort(T obj,out TimeSpan timeTaken);

    }
}
