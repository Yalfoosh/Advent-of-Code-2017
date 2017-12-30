using System.Collections.Generic;
using System.Linq;

namespace AoC_20
{
    public class CollisionSystem
    {
        private List<Particle> _particles;

        public CollisionSystem(List<Particle> list)
        {
            _particles = list;
        }

        //I assume the problem is solvable by calculating the curves for every particle. However, note that I passed my Maths 2 class with a D :^)
        public int CountAfterCollisions(ulong untilTime)
        {
            List<Particle> t = new List<Particle>(_particles);

            for (ulong i = 0; i < untilTime; ++i)
            {
                var PositionCount = new Dictionary<Vector3, ulong>();

                foreach (Particle p in t)
                {
                    p.Velocity += p.Acceleration;
                    p.Position += p.Velocity;

                    if (PositionCount.ContainsKey(p.Position))
                        ++PositionCount[p.Position];
                    else
                        PositionCount.Add(p.Position, 1);
                }

                var CollisionPositions = PositionCount.Where(x => x.Value > 1)
                                                      .Select(x => x.Key);

                t = t.Where(x => !CollisionPositions.Contains(x.Position)).ToList();
            }

            return t.Count;
        }
    }
}