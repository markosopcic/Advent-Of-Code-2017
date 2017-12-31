using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayTwentyOne
{
    class Program
    {
        static void Main(string[] args)
        {
            //prvi i drugi su isti, samo se promijeni vrijednost do koje ide for petlja sa x-om
            First();
            Console.ReadKey();
        }


        static void First()
        {
            string projectFolder = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            string fileName = Path.Combine(projectFolder, @"input.txt");
            string[] result = System.IO.File.ReadAllLines(fileName);
            Dictionary<String, String> rules = new Dictionary<string, string>();
            char[][] m = new char[3][];
            char[][] end;
            m[0] = new char[] { '.', '#', '.' };
            m[1] = new char[] { '.', '.', '#' };
            m[2] = new char[] { '#', '#', '#' };
            foreach(String s in result)
            {
                String[] split = s.Split(new String[] { "=>" }, StringSplitOptions.None);
                rules.Add(split[0].Trim(), split[1].Trim());
            }
            var keys = rules.Keys;
            for (int x = 0; x < 18; x++)
            {
                int newDiv;
                int div;
                if (m.Length % 2 == 0) { div = 2; newDiv = 3; }
                else { div = 3; newDiv = 4; }

                end = new char[m.Length/div*newDiv][];
                for (int i = 0; i < end.Length; i++) end[i] = new char[end.Length];
                for (int a = 0,num=m.Length/div*m.Length/div; a < num; a++)
                {
                    char[][] m2 = new char[div][];
                    m2 = getPart(m, m2,a,div);

                    for (int i = 0; i < 4; i++)
                    {
                        if (!keys.Contains(mToString(m2))) m2 = rotate(m2);
                        else break;
                    }
                    if (!keys.Contains(mToString(m2)))
                    {
                        m2 = flip(m2);
                        for (int i = 0; i < 4; i++)
                        {
                            if (!keys.Contains(mToString(m2))) m2 = rotate(m2);
                            else break;
                            if (i == 3) throw new Exception();
                        }
                    }
                    
                    char[][] newMade = StringToM(rules[mToString(m2)],m2);
                    end = InsertMtoM(end, newMade, a, newDiv);
                }
                m = end;
                
            }
            int count = 0;
            for(int i = 0; i < m.Length; i++)
            {
                for(int j = 0; j < m[i].Length; j++)
                {
                    if (m[i][j] == '#') count++;
                }
            }
            Console.WriteLine(count);
        }

        static char[][] InsertMtoM(char[][] m,char[][] m2,int num,int div)
        {
            int red = num / (m.Length / div);
            int stup = num % (m.Length / div);
            for (int i = 0; i < div; i++)
            {
                for (int j = 0; j < div; j++)
                {
                    m[red*div + i][stup*div + j]= m2[i][j];
                }
            }
            return m;
        }


        static char[][] StringToM(String s,char[][]m)
        {
            
            String[] split = s.Split('/');
            m = new char[split.Length][];
            for (int i = 0; i < split.Length; i++)
            {
                m[i] = split[i].ToCharArray();
            }
            return m;
        }
        static char[][] getPart(char[][] m, char[][] m2,int num,int div)
        {
            int red = num / (m.Length/div);
            int stup = num % (m.Length/div);
            for(int i = 0;i<div ; i++)
            {
                m2[i] = new char[div];
                for(int j =0;j<div ; j++)
                {
                    m2[i][j] = m[red*div + i][stup*div + j];
                }
            }
            return m2;
        }

        static void printM(char[][] m)
        {
            for(int i = 0; i < m.Length; i++)
            {
                for(int j = 0; j < m[i].Length; j++)
                {
                    Console.Write(m[i][j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
        static String mToString(char[][] m)
        {
            String result = "";
            for(int i = 0; i < m.Length; i++)
            {
                for(int j = 0; j < m[i].Length; j++)
                {
                    result += m[i][j];
                }
                if (i != m.Length - 1) result += "/";
            }
            return result;
        }
        static char[][] flip2(char [][] m)
        {
            char[][] m2 = new char[2][];
            m2[0] = new char[2];
            m2[1] = new char[2];
            m2[0][0] = m[1][0];
            m2[0][1] = m[1][1];
            m2[1][0] = m[0][0];
            m2[1][1] = m[0][1];
            return m2;

        }

        static char[][] rotate2(char[][] m)
        {
            char[][] m2 = new char[2][];
            m2[0] = new char[2];
            m2[1] = new char[2];
            m2[0][0] = m[1][0];
            m2[0][1] = m[0][0];
            m2[1][0] = m[1][1];
            m2[1][1] = m[0][1];
            return m2;
        }

        static char[][] rotate3(char[][] m)
        {
            char[][] m2 = new char[3][];
            m2[0] = new char[3];
            m2[1] = new char[3];
            m2[2] = new char[3];
            m2[0][0] = m[2][0];
            m2[0][1] = m[1][0];
            m2[0][2] = m[0][0];
            m2[1][0] = m[2][1];
            m2[1][2] = m[0][1];
            m2[2][0] = m[2][2];
            m2[2][1] = m[1][2];
            m2[2][2] = m[0][2];
            m2[1][1] = m[1][1];
            return m2;
        }

        static char[][] flip3(char [][] m)
        {
            char temp;
            temp = m[0][0];
            m[0][0] = m[0][2];
            m[0][2] = temp;
            temp = m[1][0];
            m[1][0] = m[1][2];
            m[1][2] = temp;
            temp = m[2][0];
            m[2][0] = m[2][2];
            m[2][2] = temp;
            return m;
        }

        static char[][] flip(char[][] m)
        {
            if (m.Length == 2)
            {
                return flip2(m);
            }
            else return flip3(m);
        }
        static char[][] rotate(char[][] m)
        {
            if (m.Length == 2) return rotate2(m);
            else return rotate3(m);
        }
    }
}
