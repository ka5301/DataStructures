using System;
using System.Collections.Generic;
using System.Linq;

namespace AppCode.DataStructures
{
    internal class Array<T> where T : IComparable<T>
    {
        private readonly T[] _arr;
        internal T this[int i]
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
        public Array(IEnumerable<T> data)
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

        internal void Print()
        {
            for (int i = _arr.Length - 1; i >= 0; i--)
            {
                Console.WriteLine(_arr[i].ToString());
            }
        }
    }
}
