using System;
using System.Collections.Generic;

namespace AoC_20
{
    public static class Day20_1
    {
        public static void Task()
        {
            List<Particle> Cluster = new List<Particle>(Core.Input.Length);

            for(ulong i = 0; i < (ulong)Core.Input.Length; ++i)
                Cluster.Add(new Particle(i, Core.Input[i]));

            Particle ideal = new Particle(0, "p=<-11104,1791,5208>, v=<-6,36,-84>, a=<19,-5,-4>");

            foreach (Particle p in Cluster)
            {
                var PositWeight = p.Position.Weight();
                var VelocWeight = p.Velocity.Weight();
                var AccelWeight = p.Acceleration.Weight();

                var PositRated = ideal.Position.Weight();
                var VelocRated = ideal.Velocity.Weight();
                var AccelRated = ideal.Acceleration.Weight();

                if (AccelWeight < AccelRated 
                    || AccelWeight == AccelRated && VelocWeight < VelocRated
                    || AccelWeight == AccelRated && VelocWeight == VelocRated && PositWeight < PositRated)
                {
                    ideal = p;
                }
            }

            Console.WriteLine("[Task 1]   Particle " + ideal.ID + " is the closest to the center when time tends to infinity.\n");
        }
    }
}