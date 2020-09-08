using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace matrix
{
    class Program
    {
        static private int[,] array;
        static private int n, m;
        static void Input()
        {
            string[] tokens = Console.ReadLine().Split(' ');
            n = int.Parse(tokens[0]);
            m = int.Parse(tokens[1]);
            array = new int[n, m];
            for (int i = 0; i < n; i++)
            {
                int count = 0;
                string[] line = Console.ReadLine().Split(' ');
                foreach (var str in line)
                {
                    array[i, count++] = int.Parse(str);
                }
            }
        }
        static bool JudgeMatrix()
        {
            bool flag = true;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; i + j < n && i + j < m; j++)
                {
                    if (array[i + j, j] != array[i, 0])
                    {
                        flag = false;
                        break;
                    }
                }
            }
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; i + j < n && i + j < m; j++)
                {
                    if (array[j, i + j] != array[0, i])
                    {
                        flag = false;
                        break;
                    }
                }
            }
            return flag;
        }
        static void Main(string[] args)
        {
            Input();
            if (JudgeMatrix())
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
            while (true) ;
        }
    }
}
