using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            var graph = new List<List<(int, int)>> { new List<(int,int)>{(1,6), (3, 4)},
                                              new List<(int,int)>{(2,3), (3, 2)},
                                              new List<(int,int)>{(4, 4)},
                                              new List<(int,int)>{(1,1), (2, 9), (4, 3)},
                                              new List<(int,int)>{(0,7),(2,5)} };

            var g = new Graph(graph);
            var container = new GraphContainer(g);
            container.Dijkstra(g.AdjacencyList.First());
            var g2 = new Graph(graph);
            var container2 = new GraphContainer(g2);
            container2.BellmanFord(g2.AdjacencyList.First());

            string x = "abcd", y = "abcdef";

            var l = String.ComputeLCSTable(x, y);

            var result = String.AssembleLCS(x, y, l, x.Length, y.Length);

            Console.WriteLine(result);

            x = "ACAAGC";
            y = "CCGT";

            var r = String.ComputeTransformTables(x, y, -1, 1, 2, 2);

            var transformations = String.AssembleTransformation(r.Item2, r.Item2.GetLength(0) - 1, r.Item2.GetLength(1) - 1, new Stack<String.Operation>());

            var t = "GTAACAGTAAACG";

            var nextState = String.GetNextState(t, "AAC");

            String.FAStringMatcher(t, nextState, 3);

            var res = Cryptography.Euclid(7, 13);

            var res1 = Cryptography.ModularExponentiation(3, 10, 13);

            Console.ReadLine();
        }
    }
}
