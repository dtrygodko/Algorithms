using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            var graph = new List<List<(int, int)>> { new List<(int,int)>{(2,1)},
                                              new List<(int,int)>{(3,3)},
                                              new List<(int,int)>{(3, 4), (4,0)},
                                              new List<(int,int)>{(5,6)},
                                              new List<(int,int)>{(5,3)},
                                              new List<(int,int)>{(6, 1), (10,0)},
                                              new List<(int,int)>{(7,8)},
                                              new List<(int,int)>{(12,12)},
                                              new List<(int,int)>{(9,4)},
                                              new List<(int,int)>{(10,3)},
                                              new List<(int,int)>{(11,7)},
                                              new List<(int,int)>{(12,3)},
                                              new List<(int,int)>{(13,2)},
                                              new List<(int,int)>()};

            var g = new Graph(graph);
            var container = new GraphContainer(g);
            container.DagShortestPaths(g.AdjacencyList.First());
            var g2 = new Graph(graph);
            var container2 = new GraphContainer(g2);
            container2.DagShortestPaths(g2.AdjacencyList.First());
            Console.WriteLine("adsa");
        }
    }
}
