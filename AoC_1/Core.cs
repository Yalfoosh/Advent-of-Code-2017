using System;

namespace AoC_1
{
    class Core
    {
        static void Main(string[] args)
        {
            try
            {
                int mode = int.Parse(args[0]);

                switch (mode)
                {
                    case 1:
                        Day1_1.Task1(args[1]);
                        break;
                    case 2:
                        Day1_2.Task2(args[1]);
                        break;
                    default:
                        Day1_1.Task1(args[1]);
                        Day1_2.Task2(args[1]);
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            Console.Read();
        }
    }
}