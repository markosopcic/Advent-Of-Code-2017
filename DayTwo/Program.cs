using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayTwo
{
    class Program
    {
        static void Main(string[] args)
        {
            string projectFolder = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            string fileName = Path.Combine(projectFolder, @"input.txt");
            string[] result = System.IO.File.ReadAllLines(fileName);
            Second(result);
        }

        private static void First(string[] args)
        {
            int checksum = 0;
            for(int i = 0; i < args.Length; i++)
            {
                String[] line = args[i].Split('\t');
                int min = 0;int max = 0;
                min = int.Parse(line[0]);
              for(int j = 0; j < line.Length; j++)
                {
                    int num = int.Parse(line[j]);
                    if (num > max) max = num;
                    if (num < min) min = num;
                }
                checksum += max - min;
                max = 0;
            }
            Console.Write(checksum);
            Console.ReadKey();
        }

        private static void Second(String[] args)
        {
            int sum = 0;
            for(int i = 0; i < args.Length; i++)
            {

                List<int> line = new List<int>();
                String[] lineString = args[i].Split('\t');
                for(int j = 0; j < lineString.Length; j++)
                {
                    line.Add(int.Parse(lineString[j]));
                }
                int[] nums = line.ToArray();
                for(int j = 0; j < nums.Length; j++)
                {
                    for(int x = 0; x < nums.Length; x++)
                    {
                        if (x == j)
                        {
                            continue;
                        }
                        if (nums[x] % nums[j] == 0)
                        {
                            sum += nums[x] / nums[j];
                            break;
                        }
                    }
                }
            }
            Console.WriteLine(sum);
            Console.ReadKey();
        }
    }
}
