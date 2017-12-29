using System;

namespace AoC_13
{
    public static class Day13_2
    {
        public static void Task()
        {
            Firewall t = new Firewall(Core.Parameters);

            Console.WriteLine("[Task 2]   To safely pass through the firewall, you would need to delay your entry for " + t.MinimumSafeDelay() + " picoseconds.");
        }
    }
}