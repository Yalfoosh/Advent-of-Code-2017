using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC_9
{
    public static class Day9_1
    {
        public static ulong GroupWeight(string input)
        {
            ulong toRet = 0;
            ulong worth = 1;

            for (int i = 0; i < input.Length; ++i)
            {
                switch (input[i])
                {
                    case '{':
                        toRet += worth++;
                        break;
                    case '}':
                        worth--;
                        break;
                }
            }

            return toRet;
        }

        public static void Task()
        {
            Console.WriteLine("[Task 1]   The total group weight is " + GroupWeight(Core.input) + ".\n");
        }
    }
}