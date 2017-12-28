using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC_12
{
    public static class Day12_2
    {
        private static HashSet<int> VisitedPipelines;

        public static void Task()
        {
            var t = Core.Connections;
            ulong count = 0;

            while (t.Count > 0)
            {
                VisitedPipelines = new HashSet<int>();
                VisitPipeline(Core.Connections.Keys.FirstOrDefault());

                foreach (int i in VisitedPipelines)
                    t.Remove(i);

                ++count;
            }

            Console.WriteLine("[Task 2]   There are a grand total of " + count + " groups.");
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