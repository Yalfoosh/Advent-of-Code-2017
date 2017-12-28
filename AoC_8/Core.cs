using System;
using System.IO;

namespace AoC_8
{
    class Core
    {
        public static string[] input = File.ReadAllLines(Directory.GetCurrentDirectory() + "\\input.txt");
        public static Evaluator eval = new Evaluator();

        public static void Main(string[] args)
        {
            eval.Execute(input);

            try
            {
                Day8_1.Task();
                Day8_2.Task();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            Console.Read();
        }
    }
}