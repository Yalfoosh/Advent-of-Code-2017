using System;
using System.IO;

namespace AoC_20
{
    class Core
    {
        public static string[] Input = File.ReadAllLines(Directory.GetCurrentDirectory() + "\\input.txt");
        public static ulong CrunchTime = 1000000;

        static void Main(string[] args)
        {
            try
            {
                Day20_1.Task();
                Day20_2.Task();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            Console.Read();
        }
    }
}