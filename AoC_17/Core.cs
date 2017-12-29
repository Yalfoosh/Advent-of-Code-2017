using System;

namespace AoC_17
{
    class Core
    {
        public const int Steps = 343;

        static void Main(string[] args)
        {
            try
            {
                Day17_1.Task();
                Day17_2.Task();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            Console.Read();
        }
    }
}