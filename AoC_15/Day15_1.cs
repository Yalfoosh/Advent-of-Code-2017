using System;

namespace AoC_15
{
    public static class Day15_1
    {
        public static void Task()
        {
            Generator A = new Generator(Core.StartingA, Core.MultiplierA);
            Generator B = new Generator(Core.StartingB, Core.MultiplierB);

            Judge J = new Judge(A, B);

            Console.WriteLine("[Task 1]   There are " + J.Evaluate(Core.RunsTask1) + " matching pairs.\n");
        }
    }
}