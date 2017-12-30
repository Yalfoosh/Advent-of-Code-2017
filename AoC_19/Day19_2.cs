using System;

namespace AoC_19
{
    public static class Day19_2
    {
        public static void Task()
        {
            Walker w = new Walker(Core.Input);

            Console.WriteLine("[Task 2]   A total of " + w.StepsTotal() + " steps are needed.");
        }
    }
}