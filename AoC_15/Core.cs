using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC_15
{
    class Core
    {
        public const long MultiplierA = 16807;
        public const long MultiplierB = 48271;

        public const long StartingA = 591;
        public const long StartingB = 393;

        public const long MultipleA = 4;
        public const long MultipleB = 8;

        public const ulong RunsTask1 = 40000000;
        public const ulong RunsTask2 = 5000000;

        static void Main(string[] args)
        {
            const long MultiplierA = 16807;
            const long MultiplierB = 48271;

            const long StartingA = 591;
            const long StartingB = 393;

            try
            {
                Day15_1.Task();
                Day15_2.Task();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            Console.Read();
        }
    }
}