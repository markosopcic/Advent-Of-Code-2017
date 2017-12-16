using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayFifteen
{
    class Program
    {
        static void Main(string[] args)
        {
            Second(634, 301);
        }
        public static void First(long a,long b)
        {
            int counter = 0;
            int mulb = 48271;
            int mula = 16807;
            int div = 2147483647;
            for(int i = 0; i < 40000000; i++)
            {
                a = (a * mula) % div;
                b = (b * mulb) % div;
                if ((a & 0xFFFF ) == (b & 0xFFFF))
                    counter++;
            }
            Console.WriteLine(counter);
            Console.ReadKey();
        }

        public static void Second(long a, long b) {
            int counter = 0;
            Queue<long> q1, q2;
            q1 = new Queue<long>();
            q2 = new Queue<long>();
            bool first = false, second = false;
            int mulb = 48271;
            int mula = 16807;
            int div = 2147483647;
            long a1=0, a2=0;
            int sol = 0;
            while(counter<5000000)
            {
                if (a1 == 0)
                {
                    a = (a * mula) % div;
                    if (a % 4 == 0)
                        a1 = a;
                        }
                if (a2 == 0) {
                    b = (b * mulb) % div;
                    if (b % 8 == 0)
                        a2 = b;
                        }
                

                if(a1!=0 && a2!=0)
                {
                    if ((a1 & 0xFFFF) == (a2 & 0xFFFF))
                        sol++;
                        counter++;
                    a1 = 0;
                    a2 = 0;
                }
            }
            Console.WriteLine(sol);
            Console.ReadKey();
        }

    }
}
