using System;

namespace AoC_3
{
    class Core
    {
        static void Main(string[] args)
        {
            try
            {
                var argument = ulong.Parse(args[0]);
                Day3_1.Task(argument);
                Day3_2.Task(argument);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            Console.Read();
        }
    }
}