using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC_7
{
    public static class Day7_2
    {
        class Node
        {
            public string root { get; }
            public int weight { get; }

            public List<Node> holding;

            public Node(string rootName, int weight)
            {
                root = rootName;
                this.weight = weight;

                holding = new List<Node>();
            }

            public void AddConnection(Node nodeToAdd) => holding.Add(nodeToAdd);

            public bool FaultyHere()
            {
                ulong totalWeight = 0;

                for(int i = 0; i < holding.Count - 1; ++i)
                    if (holding[i].DetermineWeight() != holding[i + 1].DetermineWeight())
                        return true;

                return false;
            }

            public int DetermineDifference()
            {
                var d = new Dictionary<int, int>();

                foreach (var x in holding)
                {
                    if (d.ContainsKey(x.DetermineWeight()))
                        ++d[x.DetermineWeight()];
                    else
                        d.Add(x.DetermineWeight(), 1);
                }


            }

            public int DetermineWeight()
            {
                int w = weight;

                foreach (var x in holding)
                    w += x.DetermineWeight();

                return w;
            }
        }

        public static void Task()
        {
            var dict = new Dictionary<string, Node>();

            foreach (var x in Core.values)
                dict.Add(x[0], new Node(x[0], int.Parse(x[1])));

            foreach (var x in Core.values)
                for(int i = 2; i < x.Length; ++i)
                    dict[x[0]].AddConnection(dict[x[i]]);

            var startingNode = dict[Day7_1.MotherProgram()];

            Correct(startingNode);
        }

        static void Correct(Node start)
        {
            if (start.FaultyHere())
                start.Dete

            foreach (var x in start.holding)
                Correct(x);
        }
    }
}