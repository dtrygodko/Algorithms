using System.Collections.Generic;
using System.Linq;

namespace Algorithms
{
    class GraphNode
    {
        public int Index;
        public List<int> Adjacencies;

        public GraphNode(int index, List<int> adjacencies)
        {
            Index = index;
            Adjacencies = adjacencies;
        } 
    }

    class Graph
    {
        public List<GraphNode> AdjacencyList = new List<GraphNode>();

        public Graph(List<List<int>> list)
        {
            var i = 0;
            foreach (var node in list)
            {
                AdjacencyList.Add(new GraphNode(i, node));
                i++;
            }
        }
    }

    class GraphSort
    {
        public static Queue<int> TopologicalSort(Graph g)
        {
            var result = new Queue<int>();
            var inDegree = new int[g.AdjacencyList.Count];
            foreach (var u in g.AdjacencyList)
            {
                foreach (var v in u.Adjacencies)
                {
                    inDegree[v] = inDegree[v] + 1;
                }
            }

            var next = g.AdjacencyList.Where(node => inDegree[node.Index] == 0).ToList();
            while (next.Count > 0)
            {
                var u = next[0];
                next.RemoveAt(0);
                result.Enqueue(u.Index);
                foreach (var v in u.Adjacencies)
                {
                    inDegree[v] = inDegree[v] - 1;
                    if (inDegree[v] == 0)
                    {
                        next.Add(g.AdjacencyList[v]);
                    }
                }
            }
            return result;
        }
    }
}
