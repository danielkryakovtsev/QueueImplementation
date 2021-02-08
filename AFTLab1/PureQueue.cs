using System;

namespace AFTLab1
{
    public class PureQueue<T> : IQueue<T>
    {
        protected class QueueItem<T2>
        {
            public T2 Value { get; set; }
            public QueueItem<T2> Next { get; set; }

            public QueueItem(T2 value)
            {
                Value = value;
            }
        }

        private QueueItem<T> Next { get; set; }
        private QueueItem<T> Last { get; set; }

        private int _size;

        public PureQueue()
        {
            Next = null;
            Last = null;
            _size = 0;
        }

        public int Count => _size;

        public void Enqueue(T obj)
        { 
            var newItem = new QueueItem<T>(obj);
            if (Last != null)
                Last.Next = newItem;

            if (Next == null)
                Next = newItem;
            Last = newItem;

            _size++;
        }

        public T Dequeue()
        {
            if (Count == 0)
                throw new InvalidOperationException();

            var removed = Next;
            Next = Next.Next;
            _size--;
            return removed.Value;
        }

        public T Peek()
        {
            if (Count == 0)
                throw new InvalidOperationException();

            return Next.Value;
        }
    }
}
