using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace AoC_7
{
    class Core
    {
        public static string[] input = File.ReadAllLines(Directory.GetCurrentDirectory() + "\\input.txt");
        public static List<string[]> values = new List<string[]>();

        static void Main(string[] args)
        {
            try
            {
                foreach (string s in input)
                {
                    var x = Regex.Replace(s, @"(\(|\)| ->|,)", "");        //Remove "(", ") ->" and "," from the main string so only values are left.
                    var inp = Regex.Split(x, @"\s+");                       //Create an array of said values.

                    values.Add(inp);                                        //Add them to the list of rearranged input.
                }

                Day7_1.Task();
                Day7_2.Task();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            Console.Read();
        }
    }
}
