namespace AFTLab1
{
    using System;

    public class ArrayQueue<T> : IQueue<T>
    {
        private readonly T[] _array;
        private int _head;
        private int _tail;
        private int _size;

        public ArrayQueue() : this(256) { }

        public ArrayQueue(int capacity)
        {
            if (capacity < 0)
                throw new ArgumentOutOfRangeException("capacity");

            _array = new T[capacity];
            _head = 0;
            _tail = 0;
            _size = 0;
        }

        public int Count => _size;

        public void Enqueue(T obj)
        {
            _array[_tail] = obj;
            _tail = (_tail + 1) % _array.Length;
            _size++;
        }

        public T Dequeue()
        {
            if (Count == 0)
                throw new InvalidOperationException();

            T removed = _array[_head];
            _array[_head] = default;
            _head = (_head + 1) % _array.Length;
            _size--;
            return removed;
        }

        public T Peek()
        {
            if (Count == 0)
                throw new InvalidOperationException();

            return _array[_head];
        }
    }
}
