using System;

namespace AoC_13
{
    public static class Day13_1
    {
        public static void Task()
        {
            Firewall f = new Firewall(Core.Parameters);

            Console.WriteLine("[Task 1]   The total severity of the path is " + f.TripSeverity() + ".\n");
        }
    }
}