using System;
using System.Collections.Generic;

namespace AoC_20
{
    public static class Day20_2
    {
        public static void Task()
        {
            List<Particle> Cluster = new List<Particle>(Core.Input.Length);

            for (ulong i = 0; i < (ulong)Core.Input.Length; ++i)
                Cluster.Add(new Particle(i, Core.Input[i]));

            CollisionSystem cs = new CollisionSystem(Cluster);

            Console.WriteLine("[Task 2]   After all the collisions, there will be " + cs.CountAfterCollisions(1000) + " particles left.");
        }
    }
}