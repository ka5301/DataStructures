using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using AppCode.Interfaces;
using Microsoft.Office.Interop.Excel;

namespace AppCode.DataStructures
{
    internal class Array<T> where T : IComparable<T>
    {
        private readonly T[] _arr;
        public T this[int i]
        {
            get
            {
                if (i < 0 && i >= Count) throw new IndexOutOfRangeException();  
                return _arr[i];
            }
            set
            {
                _arr[i] = value;
            }
        }
        
        public T[] Obj { get { return _arr; } }
        
        public int Count
        {
            get { return _arr.Length; }
        }

        public Array(int n) {
            _arr = new T[n];
        }
        public Array(IQueryable<T> data)
        {
            int n = data.Count();
            _arr = new T[n];
            int i = 0;
            foreach(var item in data)
            {
                _arr[i++] = item;
            }
            //arr = data.ToArray();           
        }

    }
}
