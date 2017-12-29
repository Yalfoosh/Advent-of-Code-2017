using System;
using System.IO;
using System.Text.RegularExpressions;

namespace AoC_16
{
    class Core
    {
        public static string Input = File.ReadAllText(Directory.GetCurrentDirectory() + "\\input.txt");
        public static string[] FilteredInput = new Regex(@",").Split(Input);
        public const int FrenzyCount = 1000000000;

        static void Main(string[] args)
        {
            try
            {
                Day16_1.Task();
                Day16_2.Task();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            Console.Read();
        }
    }
}