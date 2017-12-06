using System;
using System.Collections.Generic;

namespace AoC_6
{
    public static class Day6_2
    {
        public static void Task()
        {
            var dict = new Dictionary<string, uint>();           //Storing occurences here as string hashes tied to the step number.
            var Current = Core.DeepCopy(Core.Input);
            uint step = 0;

            while (!dict.ContainsKey(Core.Hash(Current)))
            {
                dict.Add(Core.Hash(Current), step++);

                var currIndex = Core.maxIndex(Current);
                var toSpread = Current[currIndex];

                Current[currIndex] = 0;

                while (toSpread-- > 0)
                    ++Current[(++currIndex) % Current.Length];
            }

            Console.WriteLine("An infinite loop was brewed over " + (step - dict[Core.Hash(Current)]) + " iterations.");
        }
    }
}