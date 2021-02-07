namespace AFTLab1
{
    public interface IQueue<T>
    {
        T Peek();
        void Enqueue(T obj);
        T Dequeue();

        int Count { get; }
    }
}
