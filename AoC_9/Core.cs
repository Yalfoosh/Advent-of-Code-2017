using System;
using System.IO;
using System.Text.RegularExpressions;

namespace AoC_9
{
    class Core
    {
        public static string input = File.ReadAllText(Directory.GetCurrentDirectory() + "\\input.txt");
        public static string FilteredInput;

        static void Main(string[] args)
        {
            Regex Exclamation = new Regex(@"!.");
            Regex Garbage = new Regex(@"<[^>]*>");

            input = Exclamation.Replace(input, "");

            FilteredInput = input;

            input = Garbage.Replace(input, "");

            Console.WriteLine("The input is " + input + ".\n\n");

            try
            {
                Day9_1.Task();
                Day9_2.Task();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            Console.Read();
        }
    }
}