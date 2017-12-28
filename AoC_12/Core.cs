using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace AoC_12
{
    class Core
    {
        public static string[] Input = File.ReadAllLines(Directory.GetCurrentDirectory() + "\\input.txt");
        public static Dictionary<int, List<int>> Connections = new Dictionary<int, List<int>>();

        static void Main(string[] args)
        {
            foreach (string s in Input)
            {
                var t = new Regex(@" <-> |, ").Split(s);

                List<int> tt = new List<int>(t.Length - 1);

                for(int i = 1; i < t.Length; ++i)
                    tt.Add(int.Parse(t[i].Trim()));

                Connections.Add(int.Parse(t[0]), tt);
            }

            try
            {
                Day12_1.Task();
                Day12_2.Task();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            Console.Read();
        }
    }
}