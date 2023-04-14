namespace DSImplementations.AppCode.Interfaces
{
    internal interface IQueue<T>
    {
        int Count { get; }
        void Enqueue(T item);
        T Dequeue();
        T Peek();
    }
}
