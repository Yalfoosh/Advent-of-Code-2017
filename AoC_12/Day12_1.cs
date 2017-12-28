using System;
using System.Collections.Generic;

namespace AoC_12
{
    public static class Day12_1
    {
        private static HashSet<int> VisitedPipelines;

        public static void Task()
        {
            VisitedPipelines = new HashSet<int>();
            VisitPipeline(0);

            Console.WriteLine("[Task 1]   The group connected to process ID 0 contains " + VisitedPipelines.Count + " processes.\n");
        }

        private static void VisitPipeline(int ID)
        {
            if (!VisitedPipelines.Contains(ID))
            {
                VisitedPipelines.Add(ID);

                foreach (int i in Core.Connections[ID])
                    VisitPipeline(i);
            }
        }
    }
}