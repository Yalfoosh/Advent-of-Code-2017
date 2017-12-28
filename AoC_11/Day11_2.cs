using System;

namespace AoC_11
{
    public static class Day11_2
    {
        public static void Task()
        {
            Map m = new Map();

            Console.WriteLine("[Task 2] The longest path of the resulting path is " + m.FarthestPath(Core.Directions) + ".");
        }
    }
}