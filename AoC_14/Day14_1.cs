using System;

namespace AoC_14
{
    public static class Day14_1
    {
        public static void Task()
        {
            ulong OccupiedBlocks = 0;
            Hasher h = new Hasher();

            for (int i = 0; i < 128; ++i)
            {
                string t = Core.Input + "-" + i;
                h.Reset();

                OccupiedBlocks += CountBlocks(h.GetKnotHash(t));
            }

            Console.WriteLine("[Task 1]   The number of occupied blocks for the given input is " + OccupiedBlocks + ".\n");
        }

        public static ulong CountBlocks(string hash)
        {
            ulong toRet = 0;

            //Console.WriteLine(hash);

            foreach (char c in hash)
            {
                int value = 0;

                if (c >= '0' && c <= '9')
                    value = c - '0';
                else if (c >= 'a' && c <= 'f')
                    value = c - 'a' + 10;

                while (value != 0)
                {
                    ++toRet;
                    value &= value - 1;
                }
            }

            return toRet;
        }
    }
}