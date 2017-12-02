using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace AoC_2
{
    class Core
    {
        static void Main(string[] args)
        {
            Regex LineEnds = new Regex("\\n");
            Regex Numbers = new Regex("\\d+");

            var a = LineEnds.Split(File.ReadAllText(Directory.GetCurrentDirectory() + "\\input.txt"));
            var b = new List<SortedSet<ulong>>();

            //Convert the string list to a list of sorted sets. Neither of the tasks require you to keep duplicates.
            for (int i = 0; i < a.Length; ++i)
            {
                var set = new SortedSet<ulong>();
                var t = Numbers.Matches(a[i])
                               .Cast<Match>()
                               .Select(x => x.Value)
                               .ToArray();

                foreach (string num in t)
                    set.Add(ulong.Parse(num));

                b.Add(set);
            }

            b.TrimExcess();

            try
            {
                //Make sure x isn't null...
                var x = ulong.Parse(args.FirstOrDefault() == null ? "3" : args.FirstOrDefault());

                switch (x)
                {
                    case 1:
                        Day2_1.Task(b);
                        break;
                    case 2:
                        Day2_2.Task(b);
                        break;
                    default:
                        Day2_1.Task(b);
                        Day2_2.Task(b);
                        break;
                }

                Console.Read();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Console.Read();
            }
        }
    }
}