using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC_4
{
    class Day4_2
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
                    var tString = new string (x.OrderBy(c => c).ToArray());

                    if (temp.Contains(tString))
                    {
                        --count;
                        break;
                    }

                    temp.Add(tString);
                }
            }

            Console.WriteLine("In the input there were " + count + " valid passwords (out of " + input.Length + ").");
        }
    }
}
