using System;
using System.Collections.Generic;

namespace AoC_4
{
    class Day4_1
    {
        public static void Task(string[] input)
        {
            ulong count = 0;

            foreach (string s in input)
            {
                HashSet<string> temp = new HashSet<string>();
                string[] ss = Core.spaces.Split(s);

                ++count;

                foreach (string x in ss)
                {
                    if (temp.Contains(x))
                    {
                        --count;
                        break;
                    }

                    temp.Add(x);
                }
            }

            Console.WriteLine("In the input there were " + count + " valid passwords (out of " + input.Length + ").");
        }
    }
}