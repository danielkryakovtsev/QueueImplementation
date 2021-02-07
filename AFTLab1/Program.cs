using System;
using System.Linq;
using System.Collections.Generic;

namespace AFTLab1
{
    class Program
    {
        static void Main(string[] args)
        {
            var addedArray = Console.ReadLine().Split(" ").Select(i => Convert.ToInt32(i));

            IQueue<int> queue = new PureQueue<int>();
            // IQueue<int> queue = new ArrayQueue<int>(); 

            foreach (var item in addedArray)
            {
                queue.Enqueue(item);
            }

            var result = new Result
            {
                Count = queue.Count,
                Min = queue.Peek(),
                Max = queue.Peek(),
                Fourth = queue.Peek(),
                BeforeMin = queue.Peek(),
            };

            var elementBefore = queue.Peek();
            var i = 0;
            while(queue.Count > 0)
            {
                var current = queue.Dequeue();
                result.Avg += ((double)current) / result.Count;
                if (current < result.Min)
                {
                    result.Min = current;
                    result.BeforeMin = elementBefore;
                }
                if (current > result.Max) result.Max = current;
                if (i == 3) result.Fourth = current;
                elementBefore = current;
                i++;
            }

            Console.WriteLine(result.ToString());
        }

        class Result {
            public int Count;
            public double Avg;
            public int Min;
            public int Max;
            public int Fourth;
            public int BeforeMin;

            public override string ToString()
            {
                return $"Count = {Count}" + "\n" +
                    $"Avg = {Avg}" + "\n" +
                    $"Min = {Min}" + "\n" +
                    $"Max = {Max}" + "\n" +
                    $"Fourth = {Fourth}" + "\n" +
                    $"Item before min = {BeforeMin}";
            }
        }
    }
}
