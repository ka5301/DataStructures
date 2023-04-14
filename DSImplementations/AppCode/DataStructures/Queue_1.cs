using DSImplementations.AppCode.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AppCode.DataStructures
{
    internal class Queue<T> : IStack<T> where T : IComparable<T>
    {
        private int _index;
        private int _size;
        private T[] _arr;
        
        public int Count { get; private set; }
        
        public Queue() {
            Count = 0;
            _size = 2;
            _index = -1;
            _arr = new T[_size];    
        }
        public Queue(IEnumerable<T> data)
        {
            Count = 0;
            _index = -1;
            _size = data.Count();
            _arr = new T[_size];

            foreach (T item in data)
            {
                Push(item);
            }
        }

        public void Push(T record)
        {
            if (_index == _size-1)
            {
                _size *= 2;
                Array.Resize(ref _arr, _size);
            }

            Count++;
            _arr[++_index] = record;
        }
        public T Pop()
        {
            if (_index == -1)
            {
                Console.WriteLine("Your Stack is Empty");
                return default;
            }
            
            T record = _arr[_index];
            _arr[_index--] = default;
            Count--;
            return record;
        }
        public T Top()
        {
            if (_index == -1)
            {
                Console.WriteLine("Your Stack is Empty");
                return default(T);
            }

            T record = _arr[_index];
            return record;
        }

        internal void Print()
        {
            for(int i= _arr.Length -1; i>=0;i--)
            {
                Console.WriteLine(_arr[i].ToString());
            }
        }
    }
}
