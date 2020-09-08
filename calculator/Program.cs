using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calculator
{
    class Program
    {
        static void Calc(double a, double b, char op, out double res)
        {
            res = 0;
            switch (op)
            {
                case '+':
                    res = a + b;
                    break;
                case '-':
                    res = a - b;
                    break;
                case '*':
                    res = a * b;
                    break;
                case '/':
                    res = a / b;
                    break;
            }
           
        }
        static void Main(string[] args)
        {
            string[] tokens = Console.ReadLine().Split(' ');
            Calc(Convert.ToDouble(tokens[0]), 
                Convert.ToDouble(tokens[2]), 
                Convert.ToChar(tokens[1]),
                out double res);
            Console.WriteLine(res);
            while (true) ;
        }
    }
}
