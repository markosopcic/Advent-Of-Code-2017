using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_One
{
    public class DayOne
    {

        public static void main(String[] args)
        {
            var sum = 0;
            char[] chars = Console.ReadLine().ToCharArray();
            for(int i = 0; i < chars.Length-1; i++)
            {
                if (chars[i] == chars[i + 1])
                {
                    sum += chars[i] - '0';
                }
            }
            if (chars[chars.Length - 1] == chars[0]) sum += chars[0] - '0';
            Console.WriteLine(sum);
        }
        
    }
}
