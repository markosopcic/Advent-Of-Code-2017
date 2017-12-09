using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayEight
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
            Dictionary<String, int> dict = new Dictionary<string, int>();
            bool d= false;
            int max = 0;
            for(int i = 0; i < lines.Length; i++)
            {
                d= false;
                String[] split = lines[i].Split(new String[] { "if" }, StringSplitOptions.None);
                String[] cond = split[1].Trim().Split(' ');
                if (!dict.ContainsKey(cond[0]))
                {
                    dict.Add(cond[0], 0);
                }
                switch (cond[1])
                {
                    case ">":
                        {
                            if (dict[cond[0]] > Int32.Parse(cond[2])) d = true;
                            break;
                        }
                    case "<":
                        {
                            if (dict[cond[0]] < Int32.Parse(cond[2])) d = true;
                            break;
                        }
                    case ">=":
                        {
                            if (dict[cond[0]] >= Int32.Parse(cond[2])) d = true;
                            break;
                        }
                    case "<=":
                        {
                            if (dict[cond[0]] <= Int32.Parse(cond[2])) d = true;
                            break;
                        }
                    case "==":
                        {
                            if (dict[cond[0]] == Int32.Parse(cond[2])) d = true;
                            break;
                        }
                    case "!=":
                        {
                            if (dict[cond[0]] != Int32.Parse(cond[2])) d = true;
                            break;
                        }
                }
                if (d)
                {
                    String[] split2 = split[0].Split(' ');
                    if (!dict.ContainsKey(split2[0])) dict.Add(split2[0], 0);
                    switch (split2[1])
                    {
                        case "inc":
                            {
                                dict[split2[0]] = dict[split2[0]] + Int32.Parse(split2[2]);
                                if (dict[split2[0]] > max) max = dict[split2[0]];
                                break;
                            }
                        case "dec":
                            {
                                dict[split2[0]] = dict[split2[0]] - Int32.Parse(split2[2]);
                                break;
                            }
                    }
                }
            }
            Console.WriteLine(dict.Values.Max());
            Console.WriteLine(max);
            Console.ReadLine();
        }
    }
}
