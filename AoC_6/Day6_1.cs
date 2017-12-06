using System;
using System.Collections.Generic;

namespace AoC_6
{
    public static class Day6_1
    {
        public static void Task()
        {
            var set = new HashSet<string>();              //Storing occurences here as string hashes.
            var Current = Core.DeepCopy(Core.Input);

            while (!set.Contains(Core.Hash(Current)))
            {
                set.Add(Core.Hash(Current));

                var currIndex = Core.maxIndex(Current);
                var toSpread = Current[currIndex];

                Current[currIndex] = 0;

                while (toSpread-- > 0)
                    ++Current[(++currIndex) % Current.Length];
            }

            Console.WriteLine("After " + set.Count + " iterations, an infinite loop was detected.");
        }
    }
}