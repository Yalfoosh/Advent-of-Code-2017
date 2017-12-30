using System;
using System.Text.RegularExpressions;

namespace AoC_20
{
    public class Particle
    {
        public ulong ID { get; }

        public Vector3 Position { get; set; }
        public Vector3 Velocity { get; set; }
        public Vector3 Acceleration { get; set; }

        public Particle(ulong ID, string input)
        {
            this.ID = ID;

            Regex VariableSeparator = new Regex(@",");
            var Variables = new Regex(@"<[^>]+>").Matches(input);

            string[][] args = new string[3][];

            for (int i = 0; i < 3; ++i)
                args[i] = VariableSeparator.Split(Regex.Replace(Variables[i].Value, @"<|>", ""));

            Position = new Vector3(long.Parse(args[0][0]), long.Parse(args[0][1]), long.Parse(args[0][2]));
            Velocity = new Vector3(long.Parse(args[1][0]), long.Parse(args[1][1]), long.Parse(args[1][2]));
            Acceleration = new Vector3(long.Parse(args[2][0]), long.Parse(args[2][1]), long.Parse(args[2][2]));
        }

        public ulong ManhattanDistance() => Position.DistanceFromCenter();

        public Vector3 PositionAfter(ulong time)
        {
            Vector3 pos = new Vector3(Position);
            Vector3 vel = new Vector3(Velocity);
            Vector3 acc = new Vector3(Acceleration);

            for (ulong i = 0; i < time; ++i)
            {
                vel += acc;
                pos += vel;
            }

            return pos;
        }
    }
}