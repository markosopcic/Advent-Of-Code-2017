using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayTwentyThree
{
    class Program
    {
        public static int counter = 0;
        static void Main(string[] args)
        {
            First(false);
            Console.WriteLine(counter);
            Console.ReadKey();
            Console.WriteLine(Second());
            Console.ReadKey();
        }

        public static int Second()
        {
            var c = 0;
            for (int b = 106500; b <= 123500; b += 17)
            {
                if (!IsPrime(b))
                {
                    c++;
                }
            }
            return c;
        }

        static bool IsPrime(int n)
        {
            for (int j = 2; j * j <= n; j++)
            {
                if (n % j == 0) return false;
            }
            return true;
        }
        public static void First(bool second)
        {
            string projectFolder = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            string fileName = Path.Combine(projectFolder, @"input.txt");
            String[] lines = File.ReadAllLines(fileName);
            Dictionary<String, long> dict = new Dictionary<String, long>();
            if (second) dict["a"] = 1;
            long i = 0;
            while (i >= 0 && i < lines.Length)
            {
                i = parseLine(dict, lines, i);
            }
            if (second) { Console.WriteLine(dict["h"]); Console.ReadKey(); }
        }
        public static long parseLine(Dictionary<String, long> dict, String[] lines, long i)
        {
            if (i < 0 || i > lines.Length) return -1;
            var s = lines[i];
            String[] parts = s.Split(' ');
            if (dict.ContainsKey(parts[1]) == false) dict.Add(parts[1], 0);
            if (parts.Length > 2 && dict.ContainsKey(parts[2]) == false) dict.Add(parts[2], 0);
            if (parts[0].Equals("set"))
            {
                int num;
                bool parse = Int32.TryParse(parts[2], out num);
                if (parse)
                {
                    set(dict, parts[1], num);
                }
                else
                {
                    set(dict, parts[1], dict[parts[2]]);
                }
            }
            else if (parts[0].Equals("add"))
            {
                int num;
                bool parse = Int32.TryParse(parts[2], out num);
                if (parse)
                {
                    set(dict, parts[1], dict[parts[1]] + num);
                }
                else
                {
                    set(dict, parts[1], dict[parts[1]] + dict[parts[2]]);
                }
            }
            else if (parts[0].Equals("mul"))
            {
                counter++;
                int num;
                bool parse = Int32.TryParse(parts[2], out num);
                if (parse)
                {
                    set(dict, parts[1], dict[parts[1]] * num);
                }
                else
                {
                    set(dict, parts[1], dict[parts[1]] * dict[parts[2]]);
                }
            }
            else if (parts[0].Equals("mod"))
            {
                int num;
                bool parse = Int32.TryParse(parts[2], out num);
                if (parse)
                {
                    set(dict, parts[1], dict[parts[1]] % num);
                }
                else
                {
                    set(dict, parts[1], dict[parts[1]] % dict[parts[2]]);
                }
            }
            else if (parts[0].Equals("sub"))
            {
                int num;
                bool parse = Int32.TryParse(parts[2], out num);
                if (parse)
                {
                    set(dict, parts[1], dict[parts[1]] - num);
                }
                else
                {
                    set(dict, parts[1], dict[parts[1]] - dict[parts[2]]);
                }
            }
            else
            {
                int num;
                bool parse = Int32.TryParse(parts[1], out num);
                if (parse)
                {
                    if (num != 0)
                    {
                        int num2;
                        bool parse2 = Int32.TryParse(parts[2], out num2);
                        if (parse2)
                        {
                            i += num2;
                            return i;
                        }
                        else
                        {
                            i += dict[parts[2]];
                            return i;
                        }
                    }
                }
                else
                {
                    if (dict[parts[1]] != 0)
                    {
                        parse = Int32.TryParse(parts[2], out num);
                        if (parse)
                        {
                            i += num;
                            return i;
                        }
                        else
                        {
                            i += dict[parts[1]];
                            return i;
                        }

                    }
                }
            }
            i++;
            return i;
        }
        public static void set(Dictionary<String, long> dict, String key, long value)
        {
            if (dict.ContainsKey(key) == false) dict.Add(key, value);
            else dict[key] = value;
            return;
        }
    }
}
