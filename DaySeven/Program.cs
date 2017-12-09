using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaySeven
{
    class Program
    {
        static void Main(string[] args)
        {
            Second();
        }


        public static void Second()
        {
            string projectFolder = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            string fileName = Path.Combine(projectFolder, @"input.txt");
            String[] lines = File.ReadAllLines(fileName);
            List<Node> nodes = new List<Node>();
            foreach (String line in lines)
            {
                String value = line.Split(new String[] { "->" }, StringSplitOptions.None)[0];
                Node n = new Node(value.Trim());
                if (!nodes.Contains(n)) nodes.Add(n);
            }
            foreach (String line in lines)
            {

                String[] split = line.Split(new String[] { "->" }, StringSplitOptions.None);
                Node node = nodes.Find(n => n.Equals(new Node(split[0].Trim())));
                if (split.Length == 2)
                {
                    String children = split[1];
                    String[] ch = children.Split(',');
                    foreach (String c in ch)
                    {
                        Node n = nodes.Find(x => x.value == c.Trim());
                        node.children.Add(n);
                    }
                }
            }
            String value2 = First();
            calculateWeight(nodes.Find(c=> c.value==value2));

            Console.ReadKey();
        }

        public static void printTree(Node node,int level)
        {
            String space = "-";
            for(int i = 0; i < level; i++)
            {
                space += "-";
            }
            if (level == 0)
            {
                Console.WriteLine(node.weight+", "+node.childWeight);
            }
            foreach(Node n in node.children)
            {
                Console.WriteLine(space+n.weight+", "+n.childWeight);
                printTree(n, level + 1);
            }
        }

        public static int calculateWeight(Node node)
        {
            if (node.children.Count == 0)
            {
                return node.weight;
            }
            int weight = 0;
            foreach(Node n in node.children)
            {
                node.childWeight += calculateWeight(n);
            }
           
            int expWeight =node.childWeight/ node.children.Count;
            foreach(Node n in node.children)
            {
                if (n.weight != expWeight)
                {
                    foreach(Node n1 in node.children)
                    {
                        if (n == n1)
                        {
                            continue;
                        }
                        if ((n.weight+n.childWeight) != (n1.weight+n1.childWeight))
                        {
                            Console.WriteLine(n.value+" "+n.weight + ","+n1.value+" " + n1.weight);
                            Console.WriteLine("Weight should be:"+((n1.weight+n1.childWeight)-n.childWeight));
                        }
                    }
                }
            }
            return node.weight+node.childWeight;
        }
        public static String First()
        {
            string projectFolder = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            string fileName = Path.Combine(projectFolder, @"input.txt");
            String[] lines = File.ReadAllLines(fileName);
            List<String> lijevi = new List<String>();
            List<String> desni = new List<String>();
            foreach(String line in lines)
            {
                String value = line.Split(' ')[0];
                if (!lijevi.Contains(value.Trim())) lijevi.Add(value.Trim());
                String[] djeca = line.Split(new String[] { "->" }, StringSplitOptions.None);
                if (djeca.Length == 2)
                {
                    String[] d = djeca[1].Split(',');
                    foreach(String dd in d)
                    {
                        if (!desni.Contains(dd.Trim()))
                        {
                            desni.Add(dd.Trim());
                        }
                    }
                }
            }
             lijevi.RemoveAll(l => desni.Contains(l));
            return lijevi.ElementAt(0);

        }

       public class Node
        {
            public String value;
            public int weight;
            public int childWeight;
            public List<Node> children;

            public Node(String value)
            {
                childWeight = 0;
                children = new List<Node>();
                String[] values = value.Split(' ');
                this.value = values[0].Trim();
                if (values.Length > 1)
                    weight = Int32.Parse(values[1].Trim().Substring(1, values[1].Trim().Length - 2));
            }
            public override bool Equals(object obj)
            {
                if(this.GetType()!= obj.GetType())
                {
                    return false;
                }
                return this.value.Equals(((Node)obj).value);
            }


        }
    }

}