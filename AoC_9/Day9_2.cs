using System;
using System.Text.RegularExpressions;

namespace AoC_9
{
    public static class Day9_2
    {
        public static void Task()
        {
            Console.WriteLine("[Task 2]   There were " + CountGarbage(Core.FilteredInput) + " pieces of garbage.\n");
        }

        private static ulong CountGarbage(string input)
        {
            ulong toRet = 0;
            Regex Garbage = new Regex(@"<[^>]*>");

            var Heap = Garbage.Matches(input);

            foreach (Match m in Heap)
                toRet += (ulong)(m.Length - 2);

            return toRet;
        }
    }
}