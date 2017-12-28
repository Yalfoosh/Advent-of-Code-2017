using System;
using System.IO;
using System.Text.RegularExpressions;

namespace AoC_11
{
    class Core
    {
        public static string Input = File.ReadAllText(Directory.GetCurrentDirectory() + "\\input.txt");
        public static string[] Directions;

        static void Main(string[] args)
        {
            Regex Commas = new Regex(@",");
            Directions = Commas.Split(Input);

            try
            {
                Day11_1.Task();
                Day11_2.Task();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            Console.Read();
        }
    }
}
