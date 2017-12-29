using System;

namespace AoC_15
{
    public static class Day15_2
    {
        public static void Task()
        {
            Generator A = new Generator(Core.StartingA, Core.MultiplierA, Core.MultipleA);
            Generator B = new Generator(Core.StartingB, Core.MultiplierB, Core.MultipleB);

            Judge J = new Judge(A, B);

            Console.WriteLine("[Task 2]   There are " + J.Evaluate(Core.RunsTask2) + " matching pairs.");
        }
    }
}