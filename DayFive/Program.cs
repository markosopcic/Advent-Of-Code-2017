using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayFive
{
    class Program
    {
        static void Main(string[] args)
        {
            Second();
        }

        public static void First()
        {
            string projectFolder = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            string fileName = Path.Combine(projectFolder, @"input.txt");
            String[] lines = File.ReadAllLines(fileName);
            int[] numbers = new int[lines.Length];
            for(int i = 0; i < lines.Length; i++)
            {
                numbers[i] = Int32.Parse(lines[i]);
            }
            int counter = 0;
            int index = 0;
            int move = 0;
            while (index < numbers.Length)
            {
                move = numbers[index];
                numbers[index]++;
                index += move;
                counter++;
            }
            Console.WriteLine(counter);
            Console.ReadKey();
        }

        public static void Second()
        {
            string projectFolder = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            string fileName = Path.Combine(projectFolder, @"input.txt");
            String[] lines = File.ReadAllLines(fileName);
            int[] numbers = new int[lines.Length];
            for (int i = 0; i < lines.Length; i++)
            {
                numbers[i] = Int32.Parse(lines[i]);
            }
            int counter = 0;
            int index = 0;
            int move = 0;
            while (index < numbers.Length)
            {
                move = numbers[index];
                if (move < 3)
                {
                    numbers[index]++;
                }
                else
                {
                    numbers[index]--;
                }
                index += move;
                counter++;
            }
            Console.WriteLine(counter);
            Console.ReadKey();
        }
    }
}
