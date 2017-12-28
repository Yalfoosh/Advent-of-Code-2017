using System;
using System.Text.RegularExpressions;

namespace AoC_10
{
    public static class Day10_2
    {
        public static void Task()
        {
            Twister t = new Twister();
            string secondInput = "";

            foreach (char c in Core.Input)
                secondInput += (byte) c + ",";

            secondInput += "17,31,73,47,23";

            var si = new Regex(@",").Split(secondInput);
            var NewInput = new int[si.Length];

            for (int i = 0; i < NewInput.Length; ++i)
                NewInput[i] = int.Parse(si[i]);

            Console.WriteLine("[Task 2]   The dense hash of input.txt is " + ToHash(t.HashSequence(NewInput)) + ".");
        }

        private static string ToHash(byte[] input)
        {
            string toRet = BitConverter.ToString(input);
            return toRet.Replace("-", "").ToLower();
        }
    }
}