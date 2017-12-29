using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC_14
{
    public static class Day14_2
    {
        private static Dictionary<Tuple<int, int>, int> CheckedCoords = new Dictionary<Tuple<int, int>, int>();
        private static bool[][] DiskMap = new bool[128][];

        public static void Task()
        {
            int GlobalID = 0;
            Hasher h = new Hasher();

            for (int i = 0; i < 128; ++i)
            {
                string t = Core.Input + "-" + i;
                h.Reset();

                DiskMap[i] = HashToBinary(h.GetKnotHash(t));
            }

            for (int i = 0; i < DiskMap.Length; ++i)
                for (int j = 0; j < DiskMap[i].Length; ++j)
                    if(DiskMap[i][j] && !CheckedCoords.ContainsKey(Tuple.Create(i, j)))
                        CheckSurroundings(i, j, ++GlobalID);

            Console.WriteLine("[Task 2]   The number of groups in the memory described by the given input is " + CheckedCoords.Max(x => x.Value) + ".");
        }

        private static void CheckSurroundings(int i, int j, int groupID)
        {
            var currCoords = Tuple.Create(i, j);

            if (!CheckedCoords.ContainsKey(currCoords))
            {
                CheckedCoords.Add(currCoords, groupID);

                if (i > 0 && DiskMap[i - 1][j])
                    CheckSurroundings(i - 1, j, groupID);

                if (j > 0 && DiskMap[i][j - 1])
                    CheckSurroundings(i, j - 1, groupID);

                if (i < 127 && DiskMap[i + 1][j])
                    CheckSurroundings(i + 1, j, groupID);

                if (j < 127 && DiskMap[i][j + 1])
                    CheckSurroundings(i, j + 1, groupID);
            }
        }


        private static string HexToBinary(char hexChar)
        {
            int value = 0;
            string toRet = "";

            if (hexChar >= '0' && hexChar <= '9')
                value = hexChar - '0';
            else if (hexChar >= 'a' && hexChar <= 'f')
                value = hexChar - 'a' + 10;

            for (int i = 3; i >= 0; --i)
            {
                if (value >= basicPow(2, i))
                {
                    toRet += "1";
                    value -= basicPow(2, i);
                }
                else
                    toRet += "0";
            }

            return toRet;
        }

        private static bool[] HashToBinary(string hash)
        {
            bool[] toRet = new bool[hash.Length * 4];

            for (int i = 0; i < hash.Length; ++i)
            {
                var t = HexToBinary(hash[i]);

                for (int j = 0; j < 4; ++j)
                    toRet[4 * i + j] = t[j] == '1';
            }

            return toRet;
        }

        private static int basicPow(int x, int y)
        {
            if (y < 1)
                return 1;

            int toRet = 1;

            for (int i = 0; i < y; ++i)
                toRet *= x;

            return toRet;
        }
    }
}