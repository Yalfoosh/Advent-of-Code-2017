using System;

namespace AoC_5
{
    public static class Day5_1
    {
        public static void Task()
        {
            int index = 0;
            ulong counter = 0;

            long[] copy = new long[Core.convInput.Length];

            for (int i = 0; i < copy.Length; ++i)
                copy[i] = Core.convInput[i];

            while (true)
            {
                ++counter;

                if (index + copy[index] >= copy.Length || index + copy[index] < 0)
                    break;

                index += (int) copy[index]++;
            }

            Console.WriteLine("The number of steps required to exit the loop is: " + counter + ".");
        }
    }
}