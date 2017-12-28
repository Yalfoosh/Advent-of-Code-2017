using System;

namespace AoC_10
{
    public static class Day10_1
    {
        public static void Task()
        {
            Twister t = new Twister();

            Console.WriteLine("[Task 1]   Multiplying the first 2 transformed members of the " +
                              "chain gives us " + t.FirstTwoMultiplied(Core.FilteredInput) + ".\n");
        }
    }
}