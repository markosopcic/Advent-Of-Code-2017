using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayTwelve
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
            HashSet<int> newnums = new HashSet<int>();
            String[] zeroc = lines[0].Split(new String[] { "<->" }, StringSplitOptions.None);
            foreach (String s in zeroc[1].Split(','))
            {
                newnums.Add(Int32.Parse(s));
            }
            HashSet<int> zerocom = new HashSet<int>();
            HashSet<int> curnewnums = new HashSet<int>();
            while (newnums.Count!=0)
            {
                foreach(int i in newnums)
                {
                    String[] split = lines[i].Split(new String[] { "<->" }, StringSplitOptions.None);
                    foreach(String sp in split[1].Split(','))
                    {
                        var num = Int32.Parse(sp);
                        if (!zerocom.Contains(num))
                        {
                            curnewnums.Add(num);
                            zerocom.Add(num);
                        }
                    }
                }
                newnums = new HashSet<int>(curnewnums);
                curnewnums = new HashSet<int>();
            }
            Console.WriteLine(zerocom.Count);
            Console.ReadKey();
        }
        public static void Second()
        {
            string projectFolder = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            string fileName = Path.Combine(projectFolder, @"input.txt");
            String[] lines = File.ReadAllLines(fileName);
            HashSet<int> newnums = new HashSet<int>();

            HashSet<int> zerocom = new HashSet<int>();
            HashSet<int> curnewnums = new HashSet<int>();
            List<HashSet<int>> sets = new List<HashSet<int>>();
            foreach (String line in lines)
            {
                String[] zeroc = line.Split(new String[] { "<->" }, StringSplitOptions.None);
                foreach (String s in zeroc[1].Split(','))
                {
                    newnums.Add(Int32.Parse(s));
                }
                var n = Int32.Parse(zeroc[0].Trim());
                var b= false;
                foreach(HashSet<int> set in sets)
                {
                    if (set.Contains(n))
                    {
                        b = true;
                    }
                }
                if (!b)
                {
                    while (newnums.Count != 0)
                    {
                        foreach (int i in newnums)
                        {
                            String[] split = lines[i].Split(new String[] { "<->" }, StringSplitOptions.None);
                            foreach (String sp in split[1].Split(','))
                            {
                                var num = Int32.Parse(sp);
                                if (!zerocom.Contains(num))
                                {
                                    curnewnums.Add(num);
                                    zerocom.Add(num);
                                }
                            }
                        }
                        newnums = new HashSet<int>(curnewnums);
                        curnewnums = new HashSet<int>();
                    }
                    sets.Add(zerocom);
                }
                
                zerocom = new HashSet<int>();
            }
                Console.WriteLine(sets.Count);
                Console.ReadKey();
            }
        
    }
}
