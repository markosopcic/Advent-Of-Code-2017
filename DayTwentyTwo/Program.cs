using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayTwentyTwo
{

    enum Facing
    {
        UP, DOWN, LEFT, RIGHT


    }
    class Program
    {

        public static Facing Rotate(Facing f, bool left)
        {
            switch (left)
            {
                case true:
                    switch (f)
                    {
                        case Facing.UP: return Facing.LEFT;
                        case Facing.LEFT: return Facing.DOWN;
                        case Facing.DOWN: return Facing.RIGHT;
                        case Facing.RIGHT: return Facing.UP;
                    }
                    break;
                case false:
                    switch (f)
                    {
                        case Facing.UP: return Facing.RIGHT;
                        case Facing.RIGHT: return Facing.DOWN;
                        case Facing.DOWN: return Facing.LEFT;
                        case Facing.LEFT: return Facing.UP;
                    }
                    break;
            }
            return Facing.UP;
        }
        static void Main(string[] args)
        {
            First();
            Second();
        }


        public static void Second()
        {
            Facing f = Facing.UP;
            string projectFolder = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            string fileName = Path.Combine(projectFolder, @"input.txt");
            string[] result = System.IO.File.ReadAllLines(fileName);
            char[][] m = new char[result.Length][];
            for (int i = 0; i < result.Length; i++)
            {
                m[i] = result[i].ToCharArray();
            }
            int counter = 0;
            int xpos, ypos;
            xpos = result[0].Length / 2;
            ypos = result.Length / 2;
            for (int i = 0; i < 10000000; i++)
            {
                if (m[ypos][xpos] == '#')
                {
                    f = Rotate(f, false);
                    m[ypos][xpos] = 'F';

                }
                else if (m[ypos][xpos] == 'W')
                {
                    m[ypos][xpos] = '#';
                    counter++;
                }
                else if (m[ypos][xpos] == 'F')
                {
                    switch (f)
                    {
                        case Facing.UP:f = Facing.DOWN; break;
                        case Facing.DOWN:f = Facing.UP;break;
                        case Facing.LEFT:f = Facing.RIGHT;break;
                        case Facing.RIGHT:f = Facing.LEFT;break;
                    }
                    m[ypos][xpos] = '.';
                }
                else
                {
                    f = Rotate(f, true);
                    m[ypos][xpos] = 'W';
                }
                switch (f)
                {
                    case Facing.UP: ypos--; break;
                    case Facing.RIGHT: xpos++; break;
                    case Facing.DOWN: ypos++; break;
                    case Facing.LEFT: xpos--; break;
                }

                if (ypos >= m.Length)
                {
                    char[][] old = m;
                    m = new char[old.Length * 2][];
                    for (int j = 0; j < old.Length; j++)
                    {
                        m[j] = old[j];
                    }
                    for (int j = old.Length; j < m.Length; j++)
                    {
                        m[j] = new char[old[0].Length];
                        for (int x = 0; x < m[0].Length; x++)
                        {
                            m[j][x] = '.';
                        }
                    }

                }
                else if (ypos < 0)
                {
                    char[][] old = m;
                    m = new char[old.Length + 1][];
                    char[] dots = new char[old[0].Length];
                    for (int j = 0; j < dots.Length; j++)
                    {
                        dots[j] = '.';
                    }
                    m[0] = dots;
                    for (int j = 1; j < m.Length; j++)
                    {
                        m[j] = old[j - 1];
                    }
                    ypos++;
                }
                else
             if (xpos >= m[ypos].Length)
                {
                    char[] old = m[ypos];
                    m[ypos] = new char[old.Length * 2];
                    for (int j = 0; j < m[ypos].Length; j++)
                    {
                        if (j < old.Length)
                        {
                            m[ypos][j] = old[j];
                        }
                        else
                        {
                            m[ypos][j] = '.';
                        }
                    }
                }
                else if (xpos < 0)
                {
                    for (int j = 0; j < m.Length; j++)
                    {
                        char[] old = m[j];
                        m[j] = new char[old.Length + 1];
                        m[j][0] = '.';
                        for (int x = 0; x < old.Length; x++)
                        {
                            m[j][x + 1] = old[x];
                        }
                    }
                    xpos++;
                }

            }
            Console.WriteLine(counter);
            Console.ReadKey();
        }
        public static void First()
        {
            Facing f = Facing.UP;
            string projectFolder = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            string fileName = Path.Combine(projectFolder, @"input.txt");
            string[] result = System.IO.File.ReadAllLines(fileName);
            char[][] m = new char[result.Length][];
            for (int i = 0; i < result.Length; i++)
            {
                m[i] = result[i].ToCharArray();
            }
            int counter = 0;
            int xpos, ypos;
            xpos = result[0].Length / 2;
            ypos = result.Length / 2;
            for (int i = 0; i < 10000; i++)
            {
                if (m[ypos][xpos] == '#')
                {
                    f = Rotate(f, false);
                    m[ypos][xpos] = '.';

                }
                else
                {
                    f = Rotate(f, true);
                    m[ypos][xpos] = '#';
                    counter++;
                }
                switch (f)
                {
                    case Facing.UP: ypos--; break;
                    case Facing.RIGHT: xpos++; break;
                    case Facing.DOWN: ypos++; break;
                    case Facing.LEFT: xpos--; break;
                }

                if (ypos >= m.Length)
                {
                    char[][] old = m;
                    m = new char[old.Length * 2][];
                    for (int j = 0; j < old.Length; j++)
                    {
                        m[j] = old[j];
                    }
                    for (int j = old.Length; j < m.Length; j++)
                    {
                        m[j] = new char[old[0].Length];
                        for (int x = 0; x < m[0].Length; x++)
                        {
                            m[j][x] = '.';
                        }
                    }

                }
                else if (ypos < 0)
                {
                    char[][] old = m;
                    m = new char[old.Length + 1][];
                    char[] dots = new char[old[0].Length];
                    for (int j = 0; j < dots.Length; j++)
                    {
                        dots[j] = '.';
                    }
                    m[0] = dots;
                    for (int j = 1; j < m.Length; j++)
                    {
                        m[j] = old[j - 1];
                    }
                    ypos++;
                }
                else
             if (xpos >= m[ypos].Length)
                {
                    char[] old = m[ypos];
                    m[ypos] = new char[old.Length * 2];
                    for (int j = 0; j < m[ypos].Length; j++)
                    {
                        if (j < old.Length)
                        {
                            m[ypos][j] = old[j];
                        }
                        else
                        {
                            m[ypos][j] = '.';
                        }
                    }
                }
                else if (xpos < 0)
                {
                    for (int j = 0; j < m.Length; j++)
                    {
                        char[] old = m[j];
                        m[j] = new char[old.Length + 1];
                        m[j][0] = '.';
                        for (int x = 0; x < old.Length; x++)
                        {
                            m[j][x + 1] = old[x];
                        }
                    }
                    xpos++;
                }

            }
            Console.WriteLine(counter);
            Console.ReadKey();
        }
    }
}
