using System;

namespace AoC_11
{
    public static class Day11_1
    {
        public static void Task()
        {
            Map m = new Map();

            Console.WriteLine("[Task 1] The minimum length of the resulting path is " + m.PathLength(Core.Directions) + ".\n");
        }
    }
}