using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayNineteen
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Second(First()) ;
        }


        public static void Second(int n)
        {
            string projectFolder = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            string fileName = Path.Combine(projectFolder, @"input.txt");
            String[] lines = File.ReadAllLines(fileName);
            char[][] matrix = new char[lines.Length][];
            for (int i = 0; i < lines.Length; i++)
            {
                matrix[i] = lines[i].ToCharArray();
            }
            var count = 0;
            for(int i = 0; i < matrix.Length; i++)
            {
                for(int j = 0; j < matrix[0].Length; j++)
                {
                    if (matrix[i][j]!=' ') count++;
                }
            }
            Console.WriteLine(count+n);
            Console.ReadKey();

        }
        public static int First()
        {
            string projectFolder = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            string fileName = Path.Combine(projectFolder, @"input.txt");
            String[] lines = File.ReadAllLines(fileName);
            char[][] matrix = new char[lines.Length][];
            for (int i = 0; i < lines.Length; i++)
            {
                matrix[i] = lines[i].ToCharArray();
            }
            Direction dir = Direction.DOWN;
            Boolean hasNext = true;
            String result = "";
            int xpos, ypos;
            xpos = 0;
            ypos = 0;
            int steps = 1;
            for (int i = 0; i < matrix.Length; i++)
            {
                xpos = i;
                if (matrix[ypos][xpos] == '|') break;
            }
            bool turn = true;
            var num = 0;
            while (hasNext)
            {
                while (dir == Direction.DOWN)
                {
                    ypos++;
                    if (ypos > matrix.Length) { hasNext = false; break; }
                    if (matrix[ypos][xpos] == '-') num++;
                    if (matrix[ypos][xpos] == '|' || matrix[ypos][xpos] == '-') { steps++; continue; }
                    else if (Char.IsLetter(matrix[ypos][xpos])) { result += matrix[ypos][xpos]; steps++; }
                    else if (matrix[ypos][xpos] == '+')
                    {
                        steps++;
                        if (xpos + 1 < matrix[0].Length && (Char.IsLetter(matrix[ypos][xpos+1]) || matrix[ypos][xpos + 1] == '-')) { dir = Direction.RIGHT; xpos++;steps++; if (Char.IsLetter(matrix[ypos][xpos])) { result += matrix[ypos][xpos]; } }
                        else if (xpos - 1 >= 0 && (Char.IsLetter(matrix[ypos][xpos - 1]) || matrix[ypos][xpos - 1] == '-')) { dir = Direction.LEFT; xpos--;steps++; if (Char.IsLetter(matrix[ypos][xpos])) { result += matrix[ypos][xpos]; } }
                    }
                    else
                    {
                        hasNext = false;
                    }
                }
                while (dir == Direction.LEFT)
                {
                    xpos--;
                    if (xpos < 0) { hasNext = false; break; }
                    if (matrix[ypos][xpos] == '|') num++;
                    if (matrix[ypos][xpos] == '|' || matrix[ypos][xpos] == '-') { steps++; continue; }
                    else  if (Char.IsLetter(matrix[ypos][xpos])) { result += matrix[ypos][xpos]; steps++; }
                    else if (matrix[ypos][xpos] == '+')
                    {
                        steps++;
                        if (ypos + 1 < matrix.Length && (Char.IsLetter(matrix[ypos + 1][xpos]) || matrix[ypos + 1][xpos] == '|')) { dir = Direction.DOWN; ypos++;steps++; if (Char.IsLetter(matrix[ypos][xpos])) { result += matrix[ypos][xpos]; } }
                        else if (ypos - 1 >= 0 && (Char.IsLetter(matrix[ypos - 1][xpos]) || matrix[ypos - 1][xpos] == '|')) { dir = Direction.UP; ypos--; steps++; if (Char.IsLetter(matrix[ypos][xpos])) { result += matrix[ypos][xpos]; } }
                    }
                    else
                    {
                        hasNext = false;
                    }
                }
                while (dir == Direction.RIGHT)
                {
                    xpos++;
                    if (xpos > matrix[0].Length) { hasNext = false; break; }
                    if (matrix[ypos][xpos] == '|') num++;
                    if (matrix[ypos][xpos] == '|' || matrix[ypos][xpos] == '-') { steps++; continue; }
                    else if (Char.IsLetter(matrix[ypos][xpos])) { result += matrix[ypos][xpos]; steps++; }
                    else if (matrix[ypos][xpos] == '+')
                    {
                        steps++;
                        if (ypos + 1 < matrix.Length && (Char.IsLetter(matrix[ypos+1][xpos]) || matrix[ypos + 1][xpos] == '|')) { dir = Direction.DOWN; ypos++; steps++; if (Char.IsLetter(matrix[ypos][xpos])) { result += matrix[ypos][xpos]; } }
                        else if (ypos - 1 >= 0 && (Char.IsLetter(matrix[ypos-1][xpos])|| matrix[ypos - 1][xpos] == '|')) { dir = Direction.UP; ypos--; steps++; if (Char.IsLetter(matrix[ypos][xpos])) { result += matrix[ypos][xpos]; } }
                    }
                    else
                    {
                        hasNext = false;
                    }
                }
                while (dir == Direction.UP)
                {
                    ypos--;
                    if (ypos < 0) { hasNext = false; break; }
                    if (matrix[ypos][xpos] == '-') num++;
                    if (matrix[ypos][xpos] == '|' || matrix[ypos][xpos] == '-') { steps++; continue; }
                    else if (Char.IsLetter(matrix[ypos][xpos])) { result += matrix[ypos][xpos]; steps++; }
                    else if (matrix[ypos][xpos] == '+')
                    {
                        steps++;
                        if (xpos + 1 < matrix[0].Length && (Char.IsLetter(matrix[ypos][xpos + 1]) || matrix[ypos][xpos + 1] == '-')) { dir = Direction.RIGHT; xpos++;steps++; if (Char.IsLetter(matrix[ypos][xpos])) { result += matrix[ypos][xpos]; } }
                        else if (xpos - 1 >= 0 && (Char.IsLetter(matrix[ypos][xpos - 1]) || matrix[ypos][xpos - 1] == '-')) { dir = Direction.LEFT; xpos--; steps++;if (Char.IsLetter(matrix[ypos][xpos])) { result += matrix[ypos][xpos]; } }
                    }
                    else
                    {
                        hasNext = false;
                    }
                }
            }
            Console.WriteLine(result);
            return num;
          
        }
        public enum Direction
        {
            UP,DOWN,LEFT,RIGHT

        }
    }
    
}
