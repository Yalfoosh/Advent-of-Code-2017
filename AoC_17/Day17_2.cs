using System;

namespace AoC_17
{
    public static class Day17_2
    {
        public static void Task()
        {
            CircularBuffer c = new CircularBuffer(50000001);

            Console.WriteLine("[Task 2]   The first number after 0 is " + c.InsertVirtual(Core.Steps) + ".");
        }
    }
}