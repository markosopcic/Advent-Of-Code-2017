using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DayTen;
namespace DayFourteen
{
    class Program
    {
        static void Main(string[] args)
        {
            First("hfdlxzhv");
        }

        public static void First(String arg)
        {

            char[][] matrix = new char[128][];
            int sum = 0;
            for (int i = 0; i < 128; i++)
            {
                String curr = arg + "-" + i;
                String hex = knotHash(curr);
                string binarystring = String.Join(String.Empty,
  hex.Select(
    c => Convert.ToString(Convert.ToInt32(c.ToString(), 16), 2).PadLeft(4, '0')
  )
);
                int num = binarystring.ToCharArray().Count(c => c == '1');
                sum += num;
                matrix[i] = binarystring.ToCharArray();
            }
            Console.WriteLine(sum);
            Console.ReadLine();
            Second(matrix, sum);
        }

        public static void Second(char[][] matrix, int sum)
        {
            int groups = 0;
            int i, j;
            i = 0;j = 0;
            while (sum > 0)
            {
                
                for (i=0; i < matrix.Length; i++)
                {
                    for (j=0; j < matrix[0].Length; j++)
                    {
                        if (matrix[i][j] == '1') { groups++; goto dalje; }
                    }
                }
                dalje:if(i!=matrix.Length && j!=matrix.Length) sum -= findGroupSize(matrix, i, j);


            }
            Console.WriteLine(groups);
            Console.ReadKey();

        }

        public static int countOnes(char[][] m)
        {
            int ones = 0;
            for(int i = 0; i < m.Length; i++)
            {
                for(int j = 0; j < m.Length; j++)
                {
                    if (m[i][j] == '1') ones++;
                }
            }
            return ones;
        }
        public static int findGroupSize(char[][] m, int i, int j)
        {
            if (m[i][j] == '0') return 0;
            m[i][j] = '0';
            int sum = 0;
            if (i + 1 < m.Length) sum += findGroupSize(m, i + 1, j);
            if (i - 1 >= 0) sum += findGroupSize(m, i - 1, j);
            if (j + 1 < m.Length) sum += findGroupSize(m, i, j + 1);
            if (j - 1 >= 0) sum += findGroupSize(m, i, j - 1);
            return sum+1;

        }
        public static String knotHash(String arg)
        {
            int skip = 0;
            int currIndex = 0;
            int[] nums = new int[256];
            for (int i = 0; i < nums.Length; i++)
            {
                nums[i] = i;
            }
            char[] dd = new char[] { (char)17, (char)31, (char)73, (char)47, (char)23 };
            String[] split = arg.Split(',');
            char[] arr = arg.ToCharArray();
            arr = arr.Concat(dd).ToArray();
            int length = 0;
            for (int x = 0; x < 64; x++)
            {
                for (int i = 0; i < arr.Length; i++)
                {

                    length = arr[i];
                    for (int j = 0; j < length / 2; j++)
                    {
                        int sw = nums[(currIndex + length - j - 1) % nums.Length];
                        nums[(currIndex + length - j - 1) % nums.Length] = nums[(currIndex + j) % nums.Length];
                        nums[(currIndex + j) % nums.Length] = sw;
                    }
                    currIndex += length + skip;
                    skip++;
                }

            }
            int[] hash = new int[16];
            for (int i = 0; i < 256; i += 16)
            {
                hash[i / hash.Length] = nums[i];
                for (int j = i + 1; j < i + 16; j++)
                {
                    hash[i / hash.Length] ^= nums[j];
                }
            }
            String hex = "";
            for (int i = 0; i < hash.Length; i++)
            {
                hex += hash[i].ToString("x2");
            }
            return hex;
        }
    }
}
