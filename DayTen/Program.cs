using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayTen
{
    class Program
    {
        static void Main(string[] args)
        {
            Second(args[0]);
        }

        public static void First(String arg)
        {
            int skip = 0;
            int currIndex = 0;
            int[] nums = new int[256];
            for (int i = 0; i < nums.Length; i++)
            {
                nums[i] = i;
            }
            String[] split = arg.Split(',');
            int length;
            for (int i = 0; i < split.Length; i++)
            {
                length = Int32.Parse(split[i]);
                if (length > nums.Length)
                {
                    continue;
                }
                for (int j = 0; j < length / 2; j++)
                {
                    int sw = nums[(currIndex + length - j - 1) % nums.Length];
                    nums[(currIndex + length - j - 1) % nums.Length] = nums[(currIndex + j) % nums.Length];
                    nums[(currIndex + j) % nums.Length] = sw;
                }
                currIndex += length + skip;
                skip++;
            }
            Console.WriteLine(nums[0] * nums[1]);
            Console.ReadKey();
        }
        public static String Second(String arg)
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
            Console.WriteLine(hex);
            Console.ReadKey();
            return hex;
        }

    }
}
