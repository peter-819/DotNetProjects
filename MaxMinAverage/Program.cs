using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxMinAverage
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] array = Console.ReadLine().Split(' ');
            int max = -0x3f3f3f3f;
            int min = 0x3f3f3f3f;
            int sum = 0;
            foreach(var str in array)
            {
                int c = int.Parse(str);
                max = Math.Max(max, c);
                min = Math.Min(min, c);
                sum += c;
            }
            double average = Convert.ToDouble(sum) / array.Length;
            Console.WriteLine($"Max Number = {max}");
            Console.WriteLine($"Min Number = {min}");
            Console.WriteLine($"Average value = {average}");
            Console.WriteLine($"Sum value = {sum}");
            while (true) ;
        }
    }
}
