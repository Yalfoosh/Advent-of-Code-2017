﻿using System;
using System.IO;

namespace AoC_18
{
    class Core
    {
        public static string[] Input = File.ReadAllLines(Directory.GetCurrentDirectory() + "\\input.txt");

        static void Main(string[] args)
        {
            try
            {
                Day18_1.Task();
                Day18_2.Task();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            Console.Read();
        }
    }
}