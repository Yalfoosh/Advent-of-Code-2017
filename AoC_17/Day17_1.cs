using System;

namespace AoC_17
{
    public static class Day17_1
    {
        public static void Task()
        {
            CircularBuffer c = new CircularBuffer();

            Console.WriteLine("[Task 1]   The first number after 2017 is " + c.AtIndex(c.Load(Core.Steps)) + ".\n");
        }
    }
}