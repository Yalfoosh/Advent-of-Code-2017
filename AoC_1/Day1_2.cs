using System;

namespace AoC_1
{
    public class Day1_2
    {
        public static void Task2(string arg)
        {
            ulong result = 0;

            int shift = arg.Length / 2;
            int final = (arg.Length - 1) % arg.Length;

            if (arg[final] == arg[(shift - 1) % arg.Length])
                result += (ulong)(arg[final] - '0');

            for (int i = 0; i < final; ++i)
                if (arg[i] == arg[(i + shift) % arg.Length])
                    result += (ulong)(arg[i] - '0');

            Console.WriteLine("Z2 => " + result);
        }
    }
}