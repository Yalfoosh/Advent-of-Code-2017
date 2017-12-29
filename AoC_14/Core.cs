using System;

namespace AoC_14
{
    class Core
    {
        public static string Input = "nbysizxe";

        static void Main(string[] args)
        {
            try
            {
                Day14_1.Task();
                Day14_2.Task();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            Console.Read();
        }
    }
}