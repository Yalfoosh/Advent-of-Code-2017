using System;

namespace AoC_3
{
    public static class Day3_1
    {
        public static void Task(ulong number)
        {
            Console.WriteLine("Field number " + number + " is " + Moves(AssumeCoordinates(number)) + " moves away from the center.");
        }

        static int OddCeil(int number)
        {
            return number + (number % 2 == 0 ? 1 : 0);
        }

        static int GetRadial(ulong number)
        {
            int upperRoot = OddCeil((int)Math.Floor(Math.Sqrt(number)));

            if ((ulong) upperRoot * (ulong) upperRoot < number)
                ++upperRoot;

            upperRoot /= 2;

            return upperRoot;
        }
        static Tuple<ulong, ulong, ulong, ulong> GetPillars(int radial)
        {
            ulong coefficient = 2 * (ulong)radial + 1;
            ulong shift = coefficient - 1;

            coefficient *= coefficient;

            return Tuple.Create(coefficient, coefficient - shift, coefficient - 2 * shift, coefficient - 3 * shift);
        }

        static Tuple<int, int> AssumeCoordinates(ulong number)
        {
            var Radial = GetRadial(number);
            var Pillars = GetPillars(Radial);

            int X, Y;

            #region I am so sorry

            if (number <= Pillars.Item1 && number >= Pillars.Item2)
            {
                Y = -Radial;
                X = (int)((ulong)Radial - (Pillars.Item1 - number));
            }
            else if (number <= Pillars.Item2 && number >= Pillars.Item3)
            {
                X = -Radial;
                Y = (int)((ulong)-Radial + (Pillars.Item2 - number));
            }
            else if (number <= Pillars.Item3 && number >= Pillars.Item4)
            {
                Y = Radial;
                X = (int)((ulong)-Radial + (Pillars.Item3 - number));
            }
            else
            {
                X = Radial;
                Y = (int)((ulong)Radial - (Pillars.Item4 - number));
            }

            #endregion

            return Tuple.Create(X, Y);
        }

        static ulong Moves(Tuple<int, int> originalCoordinates)
        {
            int X = originalCoordinates.Item1, Y = originalCoordinates.Item2;
            double distance;
            ulong moves = 0;

            while (X != 0 || Y != 0)
            {
                distance = X * X + Y * Y;
                int index = 0;

                double[] distances = 
                {
                    (X - 1) * (X - 1) + Y * Y,
                    (X + 1) * (X + 1) + Y * Y,
                    X * X + (Y - 1) * (Y - 1),
                    X * X + (Y + 1) * (Y + 1)
                };

                for (int i = 0; i < distances.Length; ++i)
                {
                    distances[i] = distance - distances[i];

                    if (distances[i] > distances[index])
                        index = i;
                }

                switch (index)
                {
                    case 0:
                        --X;
                        break;
                    case 1:
                        ++X;
                        break;
                    case 2:
                        --Y;
                        break;
                    case 3:
                        ++Y;
                        break;
                }

                ++moves;
            }

            return moves;
        }
    }
}