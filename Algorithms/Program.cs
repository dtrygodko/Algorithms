using System.Collections.Generic;

namespace Algorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            var graph = new List<List<int>> { new List<int>{2},
                                              new List<int>{3},
                                              new List<int>{3, 4},
                                              new List<int>{5},
                                              new List<int>{5},
                                              new List<int>{6, 10},
                                              new List<int>{7},
                                              new List<int>{12},
                                              new List<int>{9},
                                              new List<int>{10},
                                              new List<int>{11},
                                              new List<int>{12},
                                              new List<int>{13},
                                              new List<int>()};

            var g = new Graph(graph);
            var path = GraphSort.TopologicalSort(g);
        }
    }
}
