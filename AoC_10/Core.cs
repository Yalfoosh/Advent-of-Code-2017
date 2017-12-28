using System;
using System.IO;
using System.Text.RegularExpressions;

namespace AoC_10
{
    class Core
    {
        public static string Input = File.ReadAllText(Directory.GetCurrentDirectory() + "\\input.txt");
        public static int[] FilteredInput;

        static void Main()
        {
            Regex Commas = new Regex(@",");

            string[] args = Commas.Split(Input);
            FilteredInput = new int[args.Length];

            for (int i = 0; i < FilteredInput.Length; ++i)
                FilteredInput[i] = int.Parse(args[i]);

            try
            {
                Day10_1.Task();
                Day10_2.Task();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            Console.Read();
        }
    }
}