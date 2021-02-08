using System;

namespace AFTLab1
{
    public class PureQueue<T> : IQueue<T>
    {
        protected class Node<T2>
        {
            public T2 Value { get; set; }
            public Node<T2> Next { get; set; }

            public Node(T2 value, Node<T2> next)
            {
                Value = value;
                Next = next;
            }
        }

        private Node<T> _head { get; set; }
        private Node<T> _tail { get; set; }

        private int _size;

        public PureQueue()
        {
            _head = null;
            _tail = null;
            _size = 0;
        }

        public int Count => _size;

        public void Enqueue(T obj)
        {
            var newItem = new Node<T>(obj, null);

            if (_tail != null)
                _tail.Next = newItem;

            if (_head == null)
                _head = newItem;

            _tail = newItem;
            _size++;
        }

        public T Dequeue()
        {
            if (Count == 0)
                throw new InvalidOperationException();

            var removed = _head;
            _head = _head.Next;
            _size--;
            return removed.Value;
        }

        public T Peek()
        {
            if (Count == 0)
                throw new InvalidOperationException();

            return _head.Value;
        }
    }
}
