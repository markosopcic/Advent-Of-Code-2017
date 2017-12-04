using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayFour
{
    class Program
    {
        static void Main(string[] args)
        {
            //First();
            Second();
        }

        public static void First()
        {
            string projectFolder = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            string fileName = Path.Combine(projectFolder, @"input.txt");
            String[] lines = File.ReadAllLines(fileName);
            int counter = 0;
            bool correct = true;
            for (int x = 0; x < lines.Length; x++)
            {
                String[] parts = lines[x].Split(' ');
                for (int i = 0; i < parts.Length; i++)
                {
                    for (int j = 0; j < parts.Length; j++)
                    {
                        Console.WriteLine(parts[i] + " " + parts[j]);
                        if (i == j) { continue; }
                        if (parts[i].Equals(parts[j]))
                        {
                            correct = false;
                            break;
                        }
                    }
                }
                if (correct) counter++;
                correct = true;
            }
            Console.WriteLine(counter);
            Console.ReadKey();
        }

        public static void Second()
        {
            string projectFolder = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            string fileName = Path.Combine(projectFolder, @"input.txt");
            String[] lines = File.ReadAllLines(fileName);
            int counter = 0;
            bool correct = true;
            for (int x = 0; x < lines.Length; x++)
            {
                String[] parts = lines[x].Split(' ');
                for (int i = 0; i < parts.Length; i++)
                {
                    for (int j = 0; j < parts.Length; j++)
                    {
                        Console.WriteLine(parts[i] + " " + parts[j]);
                        if (i == j) { continue; }
                        if (IsAnagram(parts[i],parts[j]))
                        {
                            correct = false;
                            break;
                        }
                    }
                }
                if (correct) counter++;
                correct = true;
            }
            Console.WriteLine(counter);
            Console.ReadKey();
        }
        public static bool IsAnagram(string s1, string s2)
        {
            if (s1.Length != s2.Length)
                return false;

            int i = -1;

            var chars = new Dictionary<char, int>();

            Func<char, int, int, int> updateCount = (c, side, pdiff) => {
                int count = 0;
                chars.TryGetValue(c, out count);
                var newCount = count + side;
                chars[c] = newCount;
                if (count == 0)
                    return pdiff + 1;
                else if (newCount == 0)
                    return pdiff - 1;
                else
                    return pdiff;
            };

            int diff = 0;
            foreach (var c1 in s1)
            {
                i++;
                var c2 = s2[i];

                if (c1 == c2)
                    continue;

                diff = updateCount(c1, 1, diff);
                diff = updateCount(c2, -1, diff);
            }

            return diff == 0;
        }
        }
    }

    