using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayNine
{
    class Program
    {
        static void Main(string[] args)
        {
            string projectFolder = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            string fileName = Path.Combine(projectFolder, @"input.txt");
            String[] lines = File.ReadAllLines(fileName);
            FirstAndSecond(lines[0]);
        }
        public static void FirstAndSecond(String arg)
        {
            char[] array = arg.ToCharArray();
            int counter = 0;
            long result = 0;
            int level = 1;
            bool trash = false;
            int garbage = 0;
            while (counter < array.Length)
            {
                switch (array[counter])
                {
                    case '!':
                        {
                            counter++;
                            break;
                        }
                    case '{':
                        {
                            if (!trash)
                            {
                                result += level;
                                level++;
                            }
                            else garbage++;
                            break;
                        }
                    case '<':
                        {
                            if (trash) garbage++;
                            trash = true;
                            break;
                        }
                    case '>':
                        {
                            trash = false;
                            break;
                        }
                    case '}':
                        {
                            if (!trash)
                                level--;
                            else garbage++;
                            break;
                        }
                    default:
                        {
                            if (trash)
                            {
                                garbage++;
                            }
                            break;
                        }
                }
                counter++;
            }
            Console.WriteLine(result);
            Console.WriteLine(garbage);
            Console.ReadKey();
        }
    }
}
