using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayTwentyFive
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(First(12172063));
            Console.ReadKey();
        }


        public static int First(int steps)
        {
            char state = 'A';
            int currIndex = 0;
            Dictionary<int, short> traka = new Dictionary<int, short>();
            traka.Add(0, 0);
            while (steps > 0)
            {
                switch (state)
                {
                    case 'A':
                        {
                            if (!traka.ContainsKey(currIndex) || traka[currIndex]==0)
                            {
                                traka[currIndex] = 1;
                                currIndex++;
                                state = 'B';
                            }
                            else
                            {
                                traka[currIndex] = 0;
                                currIndex--;
                                state = 'C';
                            }
                            break;
                        }
                    case 'B':
                        {
                            if(!traka.ContainsKey(currIndex) || traka[currIndex] == 0)
                            {
                                traka[currIndex] = 1;
                                currIndex--;
                                state = 'A';
                            }
                            else
                            {
                                traka[currIndex] = 1;
                                currIndex--;
                                state = 'D';
                            }
                            break;
                        }
                    case 'C':
                        {
                            if(!traka.ContainsKey(currIndex) || traka[currIndex] == 0)
                            {
                                traka[currIndex] = 1;
                                currIndex++;
                                state = 'D';
                            }
                            else
                            {
                                traka[currIndex] = 0;
                                currIndex++;
                                state = 'C';
                            }
                            break;
                        }
                    case 'D':
                        {
                            if(!traka.ContainsKey(currIndex) || traka[currIndex] == 0)
                            {
                                traka[currIndex] = 0;
                                currIndex--;
                                state = 'B';
                            }
                            else
                            {
                                traka[currIndex] = 0;
                                currIndex++;
                                state = 'E';
                            }
                            break;
                        }
                    case 'E':
                        {
                            if(!traka.ContainsKey(currIndex) || traka[currIndex] == 0)
                            {
                                traka[currIndex] = 1;
                                currIndex++;
                                state = 'C';
                            }
                            else
                            {
                                traka[currIndex] = 1;
                                currIndex--;
                                state = 'F';
                            }
                            break;
                        }
                    case 'F':
                        {
                            if(!traka.ContainsKey(currIndex) || traka[currIndex] == 0)
                            {
                                traka[currIndex] = 1;
                                currIndex--;
                                state = 'E';
                            }
                            else
                            {
                                traka[currIndex] = 1;
                                currIndex++;
                                state = 'A';
                            }
                            break;
                        }
                }
                steps--;
            }
            int result = 0;
            foreach(int num in traka.Keys)
            {
                if (traka[num] == 1) result++;
            }
            return result;
        }

    }

}
