using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace AoC_6
{
    class Core
    {
        static readonly Regex Spaces = new Regex("\\s+");
        public static uint[] Input = Spaces.Split(File.ReadAllText(Directory.GetCurrentDirectory() + "\\input.txt"))
                                           .Select(uint.Parse)
                                           .ToArray();

        public static uint[] DeepCopy(uint[] origin)          //Creates a deep copy of an array, I use it so I don't F up the input, obviously.
        {
            var toRet = new uint[origin.Length];

            for (int i = 0; i < toRet.Length; ++i)
                toRet[i] = origin[i];

            return toRet;
        }

        public static string Hash(uint[] origin)          //Creates a string hash of the array.
        {
            var toRet = "";

            for (int i = 0; i < origin.Length; ++i)
                toRet += origin[i] + " ";

            return toRet;
        }

        public static int maxIndex(uint[] origin)
        {
            uint value = 0;
            int index = 0;

            for (int i = 0; i < origin.Length; ++i)
                if (origin[i] > value)
                {
                    value = origin[i];
                    index = i;
                }

            return index;
        }

        static void Main(string[] args)
        {
            try
            {
                Day6_1.Task();
                Day6_2.Task();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            Console.Read();
        }
    }
}