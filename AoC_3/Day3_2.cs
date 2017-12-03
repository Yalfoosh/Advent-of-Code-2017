using System;
using System.Collections.Generic;

namespace AoC_3
{
    public static class Day3_2
    {
        public static void Task(ulong number)
        {
            Console.WriteLine("The first number larger than " + number + " is " + Iterate(number) + ".");
        }

        static ulong Iterate(ulong until)
        {
            Dictionary<Tuple<int, int>, ulong> dict = new Dictionary<Tuple<int, int>, ulong>();
            dict.Add(Tuple.Create(0, 0), 1);
            ulong currentNum = 0;

            int X = 0, Y = 0;
            uint distanceLevel = 0;

            do
            {
                Tuple<int, int> currTuple = Tuple.Create(X, Y);

                if (!dict.ContainsKey(currTuple))
                {
                    ulong currValue = 0;

                    #region Please don't end my life

                    if (dict.TryGetValue(Tuple.Create(X + 1, Y), out var tValue))       //I AM REALLY SORRY FOR THIS, I SIMPLY DON'T KNOW HOW TO BYPASS THIS IN A DICTIONARY
                        currValue += tValue;                                            //PLEASE DON'T BEAT ME :(((((((((((((

                    if (dict.TryGetValue(Tuple.Create(X + 1, Y + 1), out tValue))
                        currValue += tValue;

                    if (dict.TryGetValue(Tuple.Create(X + 0, Y + 1), out tValue))
                        currValue += tValue;

                    if (dict.TryGetValue(Tuple.Create(X - 1, Y + 1), out tValue))
                        currValue += tValue;

                    if (dict.TryGetValue(Tuple.Create(X - 1, Y), out tValue))
                        currValue += tValue;

                    if (dict.TryGetValue(Tuple.Create(X - 1, Y - 1), out tValue))
                        currValue += tValue;

                    if (dict.TryGetValue(Tuple.Create(X, Y - 1), out tValue))
                        currValue += tValue;

                    if (dict.TryGetValue(Tuple.Create(X + 1, Y - 1), out tValue))
                        currValue += tValue;

                    #endregion

                    dict.Add(currTuple, currValue);
                    currentNum = currValue;
                }

                #region Spiraling

                if (X == distanceLevel && Y == -distanceLevel)
                {
                    ++distanceLevel;
                    ++X;
                }
                else if (X == distanceLevel)
                {
                    if (Y < distanceLevel)
                        ++Y;
                    else
                        --X;
                }
                else if (Y == distanceLevel)
                {
                    if (X > -distanceLevel)
                        --X;
                    else
                        --Y;
                }
                else if (X == -distanceLevel)
                {
                    if (Y > -distanceLevel)
                        --Y;
                    else
                        ++X;
                }
                else
                    ++X;

                #endregion
            }
            while (currentNum < until);

            return currentNum;
        }
    }
}