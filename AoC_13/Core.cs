using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace AoC_13
{
    class Core
    {
        public static string[] Input = File.ReadAllLines(Directory.GetCurrentDirectory() + "\\input.txt");
        public static List<Tuple<ulong, ulong>> Parameters = new List<Tuple<ulong, ulong>>();

        static void Main(string[] args)
        {
            Regex Splitter = new Regex(@": ");

            foreach (string s in Input)
            {
                var t = Splitter.Split(s);

                Parameters.Add(new Tuple<ulong, ulong>(ulong.Parse(t[0]), ulong.Parse(t[1])));
            }

            try
            {
                Day13_1.Task();
                Day13_2.Task();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            Console.Read();
        }
    }
}