using DSImplementations.AppCode.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DSImplementations.AppCode.DataStructures
{
    internal class Queue<T> : IQueue<T> where T : IComparable<T>
    {
        private T[] _arr;
        private int _front,_end,_size;

        public int Count { get; private set; }

        public Queue() 
        {
            _size = 10;
            _arr = new T[_size];
            _front = 0;
            _end = -1;
        }
        public Queue(IEnumerable<T> data)
        {
            _size = data.Count();
            _arr = new T[_size];
            _front = 0;
            _end = -1;

            foreach (T item in data)
            {
                Enqueue(item);
            }
        }

        public void Enqueue(T record)
        {
            if(_end == _size)
            {
                _size *= 2;
                Array.Resize(ref _arr, _size);
            }
            Count++;
            _arr[++_end] = record;
        }
        public T Dequeue()
        {
            if (_front < _end)
            {
                Count--;
                T record = _arr[_front];
                _arr[_front++] = default;
                return record;
            }
            else if (_front == _end)
            {
                Count--;
                T record = _arr[_front];
                _arr[_front] = default;

                _front = 0;
                _end = -1;
                return record;

            }
            Console.WriteLine("Your Queue is Empty");
            return default;
        }
        public T Peek()
        {
            if (_front > _end)
            {
                Console.WriteLine("Your Queue is Empty");
                return default;
            }
            return _arr[_front];
        }

    }
}
