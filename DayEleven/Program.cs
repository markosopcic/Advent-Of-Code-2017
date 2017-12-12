using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayEleven
{
    class Program
    {
        static void Main(string[] args)
        {
            FirstAndSecond();
        }
        public static void FirstAndSecond()
        {
            string projectFolder = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            string fileName = Path.Combine(projectFolder, @"input.txt");
            String[] lines = File.ReadAllLines(fileName);
            var dir = lines[0].Split(',');
            int x = 0;
            int y = 0;
            int z = 0;
            List<int> maxint = new List<int>();
            var maxdist = 0;


            foreach (string d in dir)
            {
                if (d == "n")
                {
                    y += 1;
                    z -= 1;
                }
                else if (d == "s")
                {
                    y -= 1;
                    z += 1;
                }
                else if (d == "ne")
                {
                    x += 1;
                    z -= 1;
                }
                else if (d == "sw")
                {
                    x -= 1;
                    z += 1;
                }
                else if (d == "nw")
                {
                    x -= 1;
                    y += 1;
                }
                else if (d == "se")
                {
                    x += 1;
                    y -= 1;
                }

                var loopdist = (Math.Abs(x) + Math.Abs(y) + Math.Abs(z)) / 2;
                maxint.Add(loopdist);
            }
            maxdist = maxint.Max();
            var dist = (Math.Abs(x) + Math.Abs(y) + Math.Abs(z)) / 2;
            Console.WriteLine(dist);
            Console.WriteLine(maxdist);
            Console.ReadKey();
        }

    }
}
