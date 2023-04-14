namespace DSImplementations.AppCode.Interfaces
{
    internal interface IStack<T>
    {
        int Count {get;}
        void Push(T item);
        T Pop();
        T Top();
    }
}
