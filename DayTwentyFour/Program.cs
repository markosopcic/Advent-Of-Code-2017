using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DayTwentyFour
{
    class Program
    {



        public static List<Thread> ts = new List<Thread>();
        static void Main(string[] args)
        {
            //nije optimizirano ali radi.
            Both();
        }

        static void Both()
        {
            string projectFolder = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            string fileName = Path.Combine(projectFolder, @"input.txt");
            string[] result = System.IO.File.ReadAllLines(fileName);
            List<Bridge> bridges = new List<Bridge>();
            for (int i = 0; i < result.Length; i++)
            {
                String[] spl = result[i].Split('/');
                bridges.Add(new Bridge(Int32.Parse(spl[0]), Int32.Parse(spl[1]), i));
            }
            List<Bridge> lefts = new List<Bridge>();
            foreach (Bridge b in bridges)
            {
                if (b.left == 0)
                {
                    lefts.Add(new Bridge(b));

                }
                if (b.right == 0)
                {
                    lefts.Add(b.Switched());
                }
            }
            foreach (Bridge b in lefts)
            {
                List<Bridge> ava = new List<Bridge>(bridges);
                if (ava.Contains(b)) ava.Remove(b);
                else if (ava.Contains(b.Switched())) ava.Remove(b.Switched());
                b.available = ava;
            }
            foreach (Bridge b in lefts)
            {
                b.Connect(0);
                b.Calculate(0, 1);
            }

            Console.WriteLine(Bridge.values.Max());
            int maxlen = Bridge.lens.Max();
            int indexmaxlen = Bridge.lens.IndexOf(maxlen);
            Console.WriteLine(Bridge.depths.Max());
            Console.WriteLine(Bridge.values.ElementAt(indexmaxlen));
            Bridge.printLongest();
            Console.ReadKey();

        }
    }

    class Bridge
    {
        public static Bridge longest;
        public static List<int> lens = new List<int>();
        public static List<int> values = new List<int>();
        public static List<int> depths = new List<int>();
        public int ID;
        public int left;
        public int right;
        public Bridge leftBridge;
        public List<Bridge> available;
        public List<Bridge> rightB;


        public static void printLongest()
        {
            List<Bridge> print = new List<Bridge>();
            Bridge las = longest;
            while (longest != null)
            {
                print.Add(longest);
                longest = longest.leftBridge;
            }
            print.Reverse();
            foreach (Bridge br in print)
            {
                Console.Write(br.left + "/" + br.right + "--");
            }
            Console.WriteLine();
            longest = las;
            foreach(Bridge br in longest.available)
            {
                Console.WriteLine(br.left + "/" + br.right);
            }
            Console.WriteLine(print.Count + longest.available.Count);
        }

        public void Calculate(int value, int len)
        {
            if (rightB == null || rightB.Count == 0)
            {
                values.Add(value + left + right);
                if (lens.Count==0 || len > lens.Max())
                    longest = this;
                lens.Add(len);
            }
            foreach (Bridge b in rightB)
            {
                b.Calculate(value + left + right, len + 1);
            }
        }

        public void Connect(int depth)
        {
            depths.Add(depth);

            if (rightB == null)
            {
                rightB = new List<Bridge>();
                List<Bridge> ava = new List<Bridge>(available);
                foreach (Bridge b in ava)
                {
                    if (b.left == this.right || this.right == b.right)
                    {
                        List<Bridge> newList = new List<Bridge>(ava);
                        Bridge br;
                        if (this.right == b.right)
                        {
                            br = b.Switched();
                        }
                        else
                        {
                            br = new Bridge(b);
                        }
                        newList.Remove(br);
                        rightB.Add(br);
                        available.Remove(b);
                        br.available = newList;
                        br.leftBridge = this;
                    }
                }
            }
            foreach (Bridge b in rightB)
            {
                b.Connect(depth + 1);
            }
        }
        public Bridge(int l, int r, int id)
        {
            left = l;
            right = r;
            ID = id;
        }

        public Bridge(Bridge b)
        {
            left = b.left;
            right = b.right;
            ID = b.ID;
            available = b.available;

        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() == this.GetType())
            {
                Bridge b = (Bridge)obj;
                if (this.ID == b.ID) return true;
            }
            return false;
        }
        public override int GetHashCode()
        {
            return ID.GetHashCode();
        }

        public Bridge Switched()
        {
            Bridge br = new Bridge(this);
            int temp = br.left;
            br.left = br.right;
            br.right = temp;
            return br;
        }
    }
}
