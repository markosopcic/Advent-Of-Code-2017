using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaySeventeen
{
    class Program
    {
        static void Main(string[] args)
        {
            Second(345);
        }

        public static void First(int input)
        {
            int currpos = 0;
            List<int> nums = new List<int>();
            nums.Add(0);
            for(int i = 1; i < 2018; i++)
            {

                currpos = (currpos + input) % nums.Count;
                nums.Insert(++currpos, i);
                
            }
            Console.WriteLine(nums.ElementAt(currpos+1));
            Console.ReadKey();
        }

        public static void Second(int input)
        {
            int currpos = 0;
            int poszero = 0;
            for (int i = 1; i < 50000000; i++)
            {
                currpos = (currpos + input) % i+1;
                if (currpos == 1) poszero = i;
            }
            Console.WriteLine(poszero);
            Console.ReadKey();
        }
    }
}
