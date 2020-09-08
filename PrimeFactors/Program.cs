using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace PrimeFactors
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = Convert.ToInt32(Console.ReadLine());
            ArrayList factors = new ArrayList();
            
            bool[] isNotPrime = new bool[num+1];
            for(int i = 2; i <= num; i++)
            {
                if (isNotPrime[i]) continue;
                for (int j = 2; j * i <= num; j++) 
                {
                    isNotPrime[j * i] = true;
                }
                if(num % i == 0)
                {
                    factors.Add(i);
                } 
            }
            foreach(var c in factors)
            {
                Console.WriteLine(c);
            }
            while (true) ;
        }
    }
}
