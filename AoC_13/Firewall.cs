using System;
using System.Collections.Generic;

namespace AoC_13
{
    public class Firewall
    {
        private Dictionary<ulong, ulong> _layers;

        public Firewall(List<Tuple<ulong, ulong>> level_depth)
        {
            _layers = new Dictionary<ulong, ulong>();

            foreach(var t in level_depth)
                _layers.Add(t.Item1, t.Item2);
        }

        private bool IsCaught(ulong level, ulong delay = 0)
        {
            if (_layers.ContainsKey(level))
            {
                if (_layers[level] < 2)
                    return true;

                return ScannerPosition(_layers[level], level + delay) == 0;
            }
            

            return false;
        }

        private ulong ScannerPosition(ulong depth, ulong time)    //Time starts at 0.
        {
            ulong realDepth = 2 * depth - 2;  //Solving it through virtual loop.
            ulong virtualHit = time % realDepth;

            return virtualHit < depth ? virtualHit : realDepth - virtualHit;    //If the virtual hit is from [0, depth - 1], then it is the normal run,
        }                                                                       //otherwise, it will be the mirrored one, hence realDepth - virtualHit.

        public ulong TripSeverity(ulong delay = 0)
        {
            ulong toRet = 0;

            foreach (var x in _layers)
                if (IsCaught(x.Key, delay))
                    toRet += x.Key * x.Value;

            return toRet;
        }

        public ulong MinimumSafeDelay()
        {
            for(ulong i = 0; i <= ulong.MaxValue; ++i)
                if (!IsCaught(0, i) && TripSeverity(i) == 0)
                    return i;

            return ulong.MaxValue;
        }
    }
}