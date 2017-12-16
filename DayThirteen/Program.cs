using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayThirteen
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
            Dictionary<int, int> depths = new Dictionary<int, int>();
           
            foreach(String line in lines)
            {
                String[] split = line.Split(':');
                depths.Add(Int32.Parse(split[0]), Int32.Parse(split[1]));
            }
            List<int> keys = depths.Select(x => x.Key).ToList();
            int pos = 0;
            int sum = 0;
            bool[] down = new bool[keys.Max()+1];
            int[] curr = new int[keys.Max()+1];
            for (int i = 0; i < curr.Length; i++) {
                if (depths.ContainsKey(i))
                {
                    curr[i] = 1;
                }
                else
                {
                    curr[i] = -1;
                }
                down[i] = true;
            }
            for(int i = 0; i < down.Length; i++)
            {
                
                if(i!=0) pos++;
                if (curr[pos] == 1 && depths.ContainsKey(pos))
                {
                    sum += pos * depths[pos];
                }
                for(int j = 0; j < curr.Length; j++)
                {
                    if (curr[j] == -1) continue;
                    if (down[j]) curr[j]++;
                    else curr[j]--;
                    
                    if (curr[j] == depths[j] || curr[j]==1) down[j] = !down[j];
                }
            }
            Console.WriteLine(sum);
            Console.ReadKey();
        }

        public static void Second()
        {
            string projectFolder = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            string fileName = Path.Combine(projectFolder, @"input.txt");
            String[] lines = File.ReadAllLines(fileName);
            Dictionary<int, int> depths = new Dictionary<int, int>();

            foreach (String line in lines)
            {
                String[] split = line.Split(':');
                depths.Add(Int32.Parse(split[0]), Int32.Parse(split[1]));
            }
            List<int> keys = depths.Select(x => x.Key).ToList();
            int pos = 0;
            int sum = 0;
            bool[] down = new bool[keys.Max() + 1];
            int[] curr = new int[keys.Max() + 1];
            for (int i = 0; i < curr.Length; i++)
            {
                if (depths.ContainsKey(i))
                {
                    curr[i] = 1;
                }
                else
                {
                    curr[i] = -1;
                }
                down[i] = true;
            }
            bool goodPath = false;
            int seconds = -1;
            int counter = 1;
            int print = 100;
            while (!goodPath)
            {
                goodPath = true;
                seconds++;
                for(int i = 0; i < curr.Length; i++)
                {
                    if (curr[i] == -1) continue;
                    if (getStateInSeconds(depths[i],i+seconds) == 1){
                        goodPath = false;
                        break;
                }
                }
                if (seconds > print)
                {
                    print *= 10;
                    Console.WriteLine(seconds);
                }

            }
            Console.WriteLine(seconds);
            Console.ReadKey();
        }
        public static int getStateInSeconds(int depth, int seconds)
        {
            return seconds % (depth * 2 - 2)+1;
        }


    }
}
