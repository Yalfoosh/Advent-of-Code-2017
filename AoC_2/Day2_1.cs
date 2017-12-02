using System;
using System.Collections.Generic;

namespace AoC_2
{
    public static class Day2_1
    {
        public static void Task(List<SortedSet<ulong>> entry)
        {
            ulong checksum = 0;

            foreach (SortedSet<ulong> set in entry)
                checksum += set.Max - set.Min;

            Console.WriteLine(checksum);
        }
    }
}