using System;
using System.IO;
using System.Text.RegularExpressions;

namespace AoC_4
{
    class Core
    {
        public static Regex spaces = new Regex("\\s+");

        static void Main(string[] args)
        {
            try
            {
                var input = File.ReadAllLines(Directory.GetCurrentDirectory() + "\\input.txt");

                Day4_1.Task(input);
                Day4_2.Task(input);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            Console.Read();
        }
    }
}