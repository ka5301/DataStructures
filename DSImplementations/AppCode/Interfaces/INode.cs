namespace DSImplementations.AppCode.Interfaces
{
    internal interface INode<T,U>
    {
        T Value { get; set; }
        U Next { get; set; }

    }

}
