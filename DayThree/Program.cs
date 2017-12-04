using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayThree
{
    class Program
    {
        static void Main(string[] args)
        {
            First(args[0]);
            Second(args[0]);
        }




        public static void Second(String args)
        {
            int num = Int32.Parse(args);

            int maxX = 1000;
            int maxY = 1000;
            int[,] matrix = new int[maxX, maxY];

            {
                for (int x = 0; x < maxX; ++x)
                {
                    for (int y = 0; y < maxY; ++y)
                    {
                        matrix[x, y] = 0;
                    }
                }
            }

            {
                int step = 1;
                bool secondStep = false;
                int iterate = 1;
                Dir curDir = Dir.R;

                int x = 500;
                int y = 500;
                matrix[x, y] = 1;
                int nextVal = 1;


                while (nextVal < num)
                {
                    if (iterate == 0)
                    {
                        if (secondStep)
                        {
                            ++step;
                        }

                        secondStep = !secondStep;

                        iterate = step;

                        switch (curDir)
                        {
                            case Dir.R: {
                                    curDir = Dir.U;
                                    break;
                                }
                            case Dir.U:
                                {
                                    curDir = Dir.L;
                                    break;
                                }
                            case Dir.L:
                                {
                                    curDir = Dir.D;
                                    break;
                                }
                            case Dir.D:
                                {
                                    curDir = Dir.R;
                                    break;
                                }    
                        }
                    }

                    switch (curDir)
                    {
                        case Dir.R: {
                                ++x;
                                break;
                            }
                        case Dir.U: {
                                --y;
                                break;
                            }
                        case Dir.L: {
                                --x;
                                break;
                            }
                        case Dir.D: {
                                ++y;
                                break;
                            }
                    }

                    --iterate;



                    nextVal = matrix[x - 1, y - 1] + matrix[x - 1, y] + matrix[x - 1, y + 1]
                              + matrix[x, y - 1] + matrix[x, y + 1]
                              + matrix[x + 1, y - 1] + matrix[x + 1, y] + matrix[x + 1, y + 1];

                    matrix[x, y] = nextVal;

                   
                }
                Console.WriteLine(nextVal);
                Console.ReadKey();
            }
        }




        public static void First(String args)
        {
            bool flag = false;
            int counter = 1;
            int final = Int32.Parse(args);
            int x = 0, y = 0;
            int horizontal = 1, vertical = 1;
            while (counter < final)
            {
                for (int i = 0; i < Math.Abs(horizontal); i++)
                {
                    if (horizontal > 0)
                    {
                        x++;
                        counter++;
                    }
                    else
                    {
                        x--;
                        counter++;
                    }
                    if (counter == final)
                    {
                        flag = true;
                        break;
                    }
                }
                if (flag)
                {
                    break;
                }
                if (horizontal > 0)
                {
                    horizontal++;
                    horizontal = -horizontal;
                }
                else
                {
                    horizontal--;
                    horizontal = -horizontal;
                }

                for (int j = 0; j < Math.Abs(vertical); j++)
                {
                    if (vertical > 0)
                    {
                        y++;
                        counter++;
                    }
                    else
                    {
                        y--;
                        counter++;
                    }
                    if (counter == final)
                    {
                        flag = true;
                        break;
                    }
                }
                if (flag)
                {
                    break;
                }
                if (vertical > 0)
                {
                    vertical++;
                    vertical = -vertical;
                }
                else
                {
                    vertical--;
                    vertical = -vertical;
                }


            }
            Console.WriteLine("X=" + x + " Y=" + y);
            Console.WriteLine(Math.Abs(x) + Math.Abs(y));
            Console.ReadKey();
        }

        public enum Dir
        {
            R,
            U,
            L,
            D
        }

    }
}