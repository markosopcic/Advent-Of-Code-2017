using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayEighteen
{
    class Program
    {
        public static long lastfreq;
        public static long sendFirst = 0;
        public static bool[] waiting = new bool[2];
        static void Main(string[] args)
        {
            Second();
            Console.WriteLine(sendFirst);
            Console.ReadKey();
        }

        public static void First()
        {
            string projectFolder = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            string fileName = Path.Combine(projectFolder, @"input.txt");
            String[] lines = File.ReadAllLines(fileName);
            Dictionary<String, long> dict = new Dictionary<String, long>();
            long i = 0;
            while (i>0 || i<lines.Length)
            {
                i = parseLine(dict, lines, i);
            }
        }

        public static void Second()
        {
            waiting[0] = false;
            waiting[1] = false;
            string projectFolder = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            string fileName = Path.Combine(projectFolder, @"input.txt");
            String[] lines = File.ReadAllLines(fileName);
            Dictionary<String, long> dict1 = new Dictionary<String, long>();
            Dictionary<String, long> dict2 = new Dictionary<String, long>();
            dict1.Add("p", 0);
            dict2.Add("p", 1);
            Queue<long> q1 = new Queue<long>();
            Queue<long> q2 = new Queue<long>();
            Queue<long>[] qs = new Queue<long>[2];
            qs[0] = q1;
            qs[1] = q2;
            long i0, i1;
            i0 = 0;
            i1 = 0;
            while((i0>0 || i1<lines.Length) && (i1>0 || i1<lines.Length) && (!waiting[0] || !waiting[1])){
            if(!waiting[0])
                i0 = parseLineSecond(dict1, lines, i0, qs, 0);
            if(!waiting[1])
                    i1 = parseLineSecond(dict2, lines, i1, qs, 1);
            }
        }

        public static void set(Dictionary<String, long> dict, String key, long value)
        {
            if (dict.ContainsKey(key) == false) dict.Add(key, value);
            else dict[key] = value;
            return;
        }
        public static long parseLineSecond(Dictionary<String, long> dict, String[] lines, long i,Queue<long>[] queues,int id)
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
            else if (parts[0].Equals("rcv"))
            {
                if (queues[id].Count == 0)
                {
                    waiting[id] = true;
                    return i;
                }
                waiting[id] = false;
                long rcv = queues[id].Dequeue();
                if (dict.ContainsKey(parts[1]) == false) dict.Add(parts[1], 0);
                dict[parts[1]] = rcv;

            }
            else if (parts[0].Equals("snd"))
            {
                if (id==1) sendFirst++;
                int num;
                bool parse = Int32.TryParse(parts[1], out num);
                if (parse)
                {
                    queues[1 - id].Enqueue(num);
                }
                else
                {
                    queues[1 - id].Enqueue(dict[parts[1]]);

                }
                waiting[1 - id] = false;
            }
            else if (parts[0].Equals("jgz"))
            {
                int num1;
                bool parse1 = Int32.TryParse(parts[1], out num1);
                if (parse1)
                {


                    if (num1 > 0)
                    {
                        int num;
                        bool parse = Int32.TryParse(parts[2], out num);
                        if (parse)
                        {
                            i += num;
                        }
                        else
                        {
                            i += dict[parts[2]];
                        }
                        return i;
                    }

                }
                else
                {
                    if (dict[parts[1]] > 0)
                    {
                        int num;
                        bool parse = Int32.TryParse(parts[2], out num);
                        if (parse)
                        {
                            i += num;
                        }
                        else
                        {
                            i += dict[parts[2]];
                        }
                        return i;
                    }
                }
            }
            i++;
            return i;
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
            else if (parts[0].Equals("rcv"))
            {
                if (dict[parts[1]] != 0)
                {
                    dict[parts[1]] = lastfreq;
                    Console.WriteLine(lastfreq);
                    Console.ReadKey();
                }
            }
            else if (parts[0].Equals("snd"))
            {
                lastfreq = dict[parts[1]];
            }
            else
            {
                if (dict[parts[1]] > 0)
                {
                    int num;
                    bool parse = Int32.TryParse(parts[2], out num);
                    if (parse)
                    {
                        i += num;
                    }
                    else
                    {
                        i += dict[parts[2]];
                    }
                    return i;
                }
            }
            i++;
            return i;
        }
        
    }
}
  
