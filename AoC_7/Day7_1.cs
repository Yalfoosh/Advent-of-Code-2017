using System;
using System.Collections.Generic;

namespace AoC_7
{
    public static class Day7_1
    {
        public static void Task()
        {
            Console.WriteLine("The mother-program is called " + MotherProgram() + ".");
        }

        public static string MotherProgram()
        {
            var dict = new Dictionary<string, string>();    //First is some string, the second is its mother-string. Since all strings belong to one string, 
                                                            //choosing any string will eventually lead you to the original string.

            foreach (var s in Core.values)
                for (int i = 2; i < s.Length; ++i)
                    dict.Add(s[i], s[0]);

            string TheOne = Core.values[0][0];

            while (dict.ContainsKey(TheOne))
                TheOne = dict[TheOne];

            return TheOne;
        }
    }
}