using System;

namespace AoC_1
{
    public class Day1_1
    {
        public static void Task1(string arg)
        {
            ulong result = 0;

            int final = (arg.Length - 1) % arg.Length;

            if (arg[final] == arg[0])
                result += (ulong) (arg[0] - '0');

            for (int i = 0; i < final; ++i)
                if (arg[i] == arg[i + 1])
                    result += (ulong) (arg[i] - '0');

            Console.WriteLine("Z1 => " + result);
        }
    }
}