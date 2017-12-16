using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaySixteen
{
    class Program
    {
        static void Main(string[] args)
        {
            Second(First(null));
        }


        public static void Second(char[] oldProgs)
        {
            char[] progs = new char[16];
            char[] orig = new char[16];
            for (int i = 0; i < progs.Length; i++)
            {
                progs[i] = oldProgs[i];
                orig[i]= (char)((int)'a' + i); 
            }
            List<List<char>> lists = new List<List<char>>();
            lists.Add(progs.ToList());
            var num = 1000000000;
            bool flag = false;
            long  index=0;
    for (long i=1;i<num ; i++)
            {
                progs = First(progs);

                foreach(List<char> list in lists)
                {
                    if (progs.SequenceEqual(list.ToArray())){
                        index = i;
                        flag = true;
                    }
                    
                }
                if (flag) break;
                lists.Add(progs.ToList());

            }
            progs = orig;
            for(int i = 0; i < num % index; i++)
            {
                progs = First(progs);
            }

            foreach (char c in progs)
            {
                Console.Write(c);
            }
            Console.ReadKey();
        }
        public static char[] First(char[]progs)
        {
            if (progs == null)
            {
                progs = new char[16];
                for (int i = 0; i < progs.Length; i++)
                {
                    progs[i] = (char)((int)'a' + i);
                }
            }
            string projectFolder = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            string fileName = Path.Combine(projectFolder, @"input.txt");
            String[] lines = File.ReadAllLines(fileName);
            String[] input = lines[0].Split(',');
                foreach (String s in input)
                {
                    if (s.StartsWith("s"))
                    {
                        var num = Int32.Parse(s.Remove(0, 1));
                        var arr = new char[progs.Length];
                        for (int i = 0; i < arr.Length; i++)
                        {
                            arr[i] = progs[(progs.Length - num + i) % progs.Length];
                        }
                        progs = arr;
                    }
                    else if (s.StartsWith("x"))
                    {
                        var str = s.Remove(0, 1);
                        var spl = str.Split('/');
                        var temp = progs[Int32.Parse(spl[0])];
                        progs[Int32.Parse(spl[0])] = progs[Int32.Parse(spl[1])];
                        progs[Int32.Parse(spl[1])] = temp;
                    }
                    else
                    {
                        var str = s.Remove(0, 1);
                        var spl = str.Split('/');
                        var list = progs.ToList();
                        var temp1 = list.IndexOf(spl[0].ToCharArray()[0]);
                        var temp2 = list.IndexOf(spl[1].ToCharArray()[0]);
                        var temp = progs[temp1];
                        progs[temp1] = progs[temp2];
                        progs[temp2] = temp;
                    }
                }
            
            foreach(char c in progs)
            {
                Console.Write(c);
            }
            Console.WriteLine();
            return progs;
        }
    }
}
