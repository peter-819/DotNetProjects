using System;

namespace GenericNodeList
{
    public class Node<T>
    {
        public Node<T> Next { get; set; }
        public T Data { get; set; }
        public Node(T t)
        {
            Next = null;
            Data = t;
        }
    }

    public class GenericList<T>
    {
        private Node<T> head;
        private Node<T> tail;

        public GenericList()
        {
            head = tail = null;
        }
        public Node<T> Head
        {
            get => head;
        }
        public void Add(T t)
        {
            Node<T> n = new Node<T>(t);
            if(tail == null)
            {
                head = tail = n;
            }
            else
            {
                tail.Next = n;
                tail = n;
            }
        }
        public void ForEach(Action<T> action)
        {
            Node<T> n = head;
            while(n != null)
            {
                action(n.Data);
                n = n.Next;
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var list = new GenericList<int>();
            for(int i = 0; i < 8; i++)
            {
                list.Add(i);
            }

            Action<int> printValue = c => Console.WriteLine($"{c}");
            list.ForEach(printValue);

            int max = 0;
            Action<int> getMax = c => max = Math.Max(max, c);
            list.ForEach(getMax);

            int min = 0;
            Action<int> getMin = c => min = Math.Min(min, c);
            list.ForEach(getMin);

            int sum = 0;
            Action<int> getSum = c => sum += c;
            list.ForEach(getSum);

            Console.WriteLine($"max value = {max}");
            Console.WriteLine($"min value = {min}");
            Console.WriteLine($"sum value = {sum}");
        }
    }
}
