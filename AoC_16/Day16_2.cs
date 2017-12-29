using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC_16
{
    public static class Day16_2
    {
        public static void Task()
        {
            Dancefloor d = new Dancefloor();
            Dictionary<string, int> ValueReappearance = new Dictionary<string, int>();

            for (int i = 0; i < Core.FrenzyCount; ++i)
            {
                var t = d.ToString();

                if (ValueReappearance.ContainsKey(t))
                {
                    int length = i - ValueReappearance[t];

                    while (i + length < Core.FrenzyCount)
                        i += length;

                    var finalOrder = ValueReappearance.FirstOrDefault(x => x.Value == Core.FrenzyCount - i)
                                                      .Key;

                    d.SetOrder(finalOrder);
                    i += ValueReappearance[d.ToString()];
                }
                else
                {
                    ValueReappearance.Add(t, i);

                    foreach (string s in Core.FilteredInput)
                        d.Command(s);
                }
            }

            Console.WriteLine("[Task 2]   The order of the programs after " + Core.FrenzyCount +" dance sessions is as follows: " + d + ".");
        }
    }
}