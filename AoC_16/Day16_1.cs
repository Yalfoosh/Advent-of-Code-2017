using System;

namespace AoC_16
{
    public static class Day16_1
    {
        public static void Task()
        {
            Dancefloor d = new Dancefloor();
            
            foreach(string s in Core.FilteredInput)
                d.Command(s);

            Console.WriteLine("[Task 1]   The order of the programs is as follows: " + d + ".\n");
        }
    }
}