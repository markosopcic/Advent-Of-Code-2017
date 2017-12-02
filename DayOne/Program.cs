using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayOne
{
    class Program
    {

        public static void Main(String[] args)
        {
            
            Second(args);
        }


        public static void Second(String[] args)
        {
         
            var sum = 0;
            char[] chars = args[0].ToCharArray();
            var listLen = chars.Length;
            for (int i = 0; i < chars.Length - 1; i++)
            {
                if (chars[i] == chars[(i + listLen/2) % listLen])
                {
                    sum += chars[i]-'0';
                }
              
            }
            
            Console.WriteLine(sum);
            Console.ReadKey();
        }

        public static void First(String[] args)
        {
            var len = 0;
            var sum = 0;
            char[] chars = args[0].ToCharArray();
            for (int i = 0; i < chars.Length - 1; i++)
            {
                if (chars[i] == chars[i + 1])
                {
                    while (i < chars.Length - 1 && chars[i] == chars[i + 1])
                    {
                        len++;
                        i++;
                    }
                }
                sum += len * (chars[i] - '0');
                len = 0;
            }
            if (chars[chars.Length - 1] == chars[0]) sum += chars[0] - '0';
            Console.WriteLine(sum);
            Console.ReadKey();
        }
    }
}
