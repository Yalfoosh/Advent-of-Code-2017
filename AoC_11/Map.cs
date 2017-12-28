namespace AoC_11
{
    public class Map
    {
        private long N, S, NW, NE, SW, SE;
        private long FurthestPath = 0;

        public long PathLength(string[] directions)
        {
            N = S = NW = NE = SW = SE = 0;

            EnterPath(directions);
            return NormalizedLength();
        }

        public long FarthestPath(string[] directions)
        {
            N = S = NW = NE = SW = SE = 0;

            EnterPathCarefully(directions);
            return FurthestPath;
        }

        private void EnterPath(string[] directions)
        {
            foreach(string s in directions)
                Walk(s);
        }

        private void EnterPathCarefully(string[] directions)
        {
            foreach (string s in directions)
            {
                Walk(s);

                var length = NormalizedLength();

                if (length > FurthestPath)
                    FurthestPath = length;
            }
        }

        public void Walk(string direction)
        {
            switch (direction)
            {
                case "n":
                    ++N;
                    break;

                case "s":
                    ++S;
                    break;

                case "nw":
                    ++NW;
                    break;

                case "ne":
                    ++NE;
                    break;

                case "sw":
                    ++SW;
                    break;

                case "se":
                    ++SE;
                    break;
            }
        }

        public long NormalizedLength()
        {
            var tN = N;
            var tS = S;

            var tNW = NW;
            var tNE = NE;
            var tSW = SW;
            var tSE = SE;

            //Firstly, eliminate opposing paths.
            if (tN >= tS) { tN -= tS; tS = 0; }
            else { tS -= tN; tN = 0; }

            if (tNW >= tSE) { tNW -= tSE; tSE = 0; }
            else { tSE -= tNW; tNW = 0; }

            if (tSW >= tNE) { tSW -= tNE; tNE = 0; }
            else { tNE -= tSW; tSW = 0; }

            //Once opposing paths are eliminate, we need to normalise neighboring double-coords.
            if (tN > 0)  //We know that S is 0.
            {
                if (tNW >= tNE)
                {
                    tNW -= tNE;
                    tN += tNE;
                    tNE = 0;
                }
                else
                {
                    tNE -= tNW;
                    tN += tNW;
                    tNW = 0;
                }
            }
            else        //Here N is 0.
            {
                if (tSW >= tSE)
                {
                    tSW -= tSE;
                    tS += tSE;
                    tSE = 0;
                }
                else
                {
                    tSE -= tSW;
                    tS += tSW;
                    tSW = 0;
                }
            }

            return tN + tS + tNW + tNE + tSW + tSE;
        }
    }
}