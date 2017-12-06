using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaySix
{
    class Program
    {
        static void Main(string[] args)
        {
            Second(args);
        }

        public static void Second(String[] args)
        {
            int loop = 0;
            int[] nums = new int[args.Length];
            for (int i = 0; i < args.Length; i++)
            {
                nums[i] = Int32.Parse(args[i]);
            }
            bool notFinished = true;

            List<List<int>> lists = new List<List<int>>();
            while (notFinished)
            {
                int num = nums.Max();
                int index = 0;
                for (int j = 0; j < nums.Length; j++)
                {
                    if (nums[j] == num)
                    {
                        nums[j] = 0;
                        index = j + 1;
                        break;
                    }
                }
                while (num > 0)
                {
                    nums[index % nums.Length]++;
                    num--;
                    index++;
                }
                loop++;
                List<int> list = new List<int>(nums);
                foreach (List<int> help in lists)
                {
                    if (list.SequenceEqual(help))
                    {
                        notFinished = false;
                    }
                }
                lists.Add(list);


            }
            int index1, index2=0;
            index1 = lists.Count-1;
            foreach(List<int> help in lists)
            {
                if (help.SequenceEqual(lists.ElementAt(lists.Count - 1)))
                {
                    index2 = lists.IndexOf(help);
                    break;
                }
            }
            Console.WriteLine(index1 - index2);
            Console.ReadKey();

        }

        public static void First(String[] args)
        {
            int loop = 0;
            int[] nums = new int[args.Length];
            for (int i = 0; i < args.Length; i++)
            {
                nums[i] = Int32.Parse(args[i]);
            }
                bool notFinished = true;
             
                List<List<int>> lists = new List<List<int>>();
                while (notFinished)
                {
                    int num = nums.Max();
                    int index = 0;
                    for(int j = 0; j < nums.Length; j++)
                    {
                        if (nums[j] == num)
                        {
                            nums[j] = 0;
                            index = j+1;
                            break;
                        }
                    }
                    while (num > 0)
                    {
                        nums[index % nums.Length]++;
                        num--;
                        index++;
                    }
                    loop++;
                    List<int> list = new List<int>(nums);
                    printList(list);
                    Console.WriteLine();
                    printArr(nums);
                Console.WriteLine();
                    foreach (List<int> help in lists)
                    {
                        if (list.SequenceEqual(help))
                        {
                            notFinished = false;
                        }
                    }
                    lists.Add(list);
                    
                
            }
            Console.WriteLine(loop);
            Console.ReadKey();

        }

        public static void printList(List<int> list)
        {
            foreach(int num in list)
            {
                Console.Write(num + " ");
            }

        }
        public static void printArr(int[] list)
        {
            foreach (int num in list)
            {
                Console.Write(num + " ");
            }

        }
    }
}
