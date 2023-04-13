using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSImplementations.AppCode.DataStructures
{
    internal class Stack<T> where T : IComparable<T>
    {
        private T[] _arr;
        
        private int _index;

        private int _size;

        public int Count { get; private set; }
        public Stack() {
            Count = 0;
            _size = 10;
            _index = -1;
            _arr = new T[_size];    
        }

        public Stack(IEnumerable<T> data)
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
            if (_index == _size)
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
    }
}
