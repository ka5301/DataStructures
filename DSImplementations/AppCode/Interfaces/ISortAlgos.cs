using AppCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCode.Interfaces
{
    internal interface ISortAlgos<T>
    {
        IEnumerable<T> BubbleSort(out TimeSpan timeTaken);
        IEnumerable<T> SelectionSort(out TimeSpan timeTaken);
        IEnumerable<T> InsertionSort(out TimeSpan timeTaken);
        IEnumerable<T> MergeSort(out TimeSpan timeTaken);
        IEnumerable<T> QuickSort(out TimeSpan timeTaken);

    }
}
