using System;
using System.IO;

namespace AoC_5
{
    class Core
    {
        static string[] input = File.ReadAllLines(Directory.GetCurrentDirectory() + "\\input.txt");
        public static long[] convInput = new long[input.Length];

        static void Main(string[] args)
        {
            try
            {
                for (int i = 0; i < input.Length; ++i)
                    convInput[i] = long.Parse(input[i]);

                Day5_1.Task();
                Day5_2.Task();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            Console.Read();
        }
    }
}