using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC_2
{
    public static class Day2_2
    {
        public static void Task(List<SortedSet<ulong>> entry)
        {
            ulong checksum = 0;

            foreach (SortedSet<ulong> set in entry)
            {
                foreach (ulong s in set)
                {
                    var temp = set.Where(x => (x > s ? x % s : s % x) == 0 && x != s)
                                  .Select(x => x > s ? x / s : s / x);

                    if (temp.Count() == 1)
                    {
                        checksum += temp.ElementAtOrDefault(0);
                        break;
                    }
                }
            }

            Console.WriteLine(checksum);
        }
    }
}