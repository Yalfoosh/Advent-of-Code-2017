using System;
using System.IO;

namespace AoC_19
{
    class Core
    {
        public static string[] Input = File.ReadAllLines(Directory.GetCurrentDirectory() + "\\input.txt");

        static void Main(string[] args)
        {
            try
            {
                Day19_1.Task();
                Day19_2.Task();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            Console.Read();
        }
    }
}
