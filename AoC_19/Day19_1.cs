using System;

namespace AoC_19
{
    public static class Day19_1
    {
        public static void Task()
        {
            Walker w = new Walker(Core.Input);

            Console.WriteLine("[Task 1]   The letters encountered are: " + w.WalkItOut() + ".\n");
        }
    }
}