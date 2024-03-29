﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms
{
    class NodeEdge
    {
        public int TargetNode;
        public int Weight;
    }


    class GraphNode
    {
        public int Index;
        public List<NodeEdge> Adjacencies;

        public GraphNode(int index, List<NodeEdge> adjacencies)
        {
            Index = index;
            Adjacencies = adjacencies;
        }

        public GraphNode Clone()
        {
            return (GraphNode)MemberwiseClone();
        }
    }

    class Graph
    {
        public List<GraphNode> AdjacencyList = new List<GraphNode>();

        public Graph(List<List<(int,int)>> list)
        {
            var i = 0;
            foreach (var node in list)
            {
                AdjacencyList.Add(new GraphNode(i, node.Select(n => {
                    (int t, int w) = n;
                    return new NodeEdge() { TargetNode = t, Weight = w };
                }).ToList()));
                i++;
            }
        }

        public int GetWeight(GraphNode u, int nodeIndex)
        {
            return u.Adjacencies.First(n => n.TargetNode == nodeIndex).Weight;
        }
    }

    class GraphSort
    {
        public static Queue<GraphNode> TopologicalSort(Graph g)
        {
            var result = new Queue<GraphNode>();
            var inDegree = new int[g.AdjacencyList.Count];
            foreach (var u in g.AdjacencyList)
            {
                foreach (var v in u.Adjacencies)
                {
                    inDegree[v.TargetNode] = inDegree[v.TargetNode] + 1;
                }
            }

            var next = g.AdjacencyList.Where(node => inDegree[node.Index] == 0).ToList();
            while (next.Count > 0)
            {
                var u = next[0];
                next.RemoveAt(0);
                result.Enqueue(u);
                foreach (var v in u.Adjacencies)
                {
                    inDegree[v.TargetNode] = inDegree[v.TargetNode] - 1;
                    if (inDegree[v.TargetNode] == 0)
                    {
                        next.Add(g.AdjacencyList[v.TargetNode]);
                    }
                }
            }
            return result;
        }
    }

    class GraphContainer
    {
        public double[] Shortest;
        public int?[] Pred;
        public Graph Graph;

        public GraphContainer(Graph g)
        {
            Shortest = new double[g.AdjacencyList.Count];
            Pred = new int?[g.AdjacencyList.Count];
            Graph = g;
        }

        public void Relax(GraphNode u, int v)
        {
            var weight = Shortest[u.Index] + Graph.GetWeight(u, v);
            if (weight < Shortest[v])
            {
                Shortest[v] = weight;
                Pred[v] = u.Index;
            }
        }

        public int GetMinShortestIndex(List<int> excludeIndex)
        {
            var shortest = Shortest.Select((el, i) => (el, i)).Where(el => {
                (double e, int i) = el;
                return !excludeIndex.Contains(i);
            }).ToArray();
            (double min, int index) = shortest[0];
            int minIndex = index;

            for (int i = 1; i < shortest.Length; ++i)
            {
                (double newShortest, int newMinIndex) = shortest[i];
                if (newShortest < min)
                {
                    min = newShortest;
                    minIndex = newMinIndex;
                }
            }

            return minIndex;
        }

        public void DagShortestPaths(GraphNode s)
        {
            var order = GraphSort.TopologicalSort(Graph);
            foreach(var v in order.Where(o => o.Index != s.Index))
            {
                Shortest[v.Index] = double.PositiveInfinity;
            }
            foreach(var u in order)
            {
                foreach (var v in u.Adjacencies)
                {
                    Relax(u, v.TargetNode);
                }
            }
        }

        public void Dijkstra(GraphNode s)
        {
            foreach (var v in Graph.AdjacencyList.Where(o => o.Index != s.Index))
            {
                Shortest[v.Index] = double.PositiveInfinity;
            }
            var q = new Dictionary<int, GraphNode>(Graph.AdjacencyList.Select(n => new KeyValuePair<int, GraphNode>(n.Index, n.Clone())));

            var removedNodeIndexes = new List<int>();

            while (q.Any())
            {
                var minShortest = GetMinShortestIndex(removedNodeIndexes);
                var u = q[minShortest];
                q.Remove(minShortest);
                removedNodeIndexes.Add(minShortest);
                foreach (var v in u.Adjacencies)
                {
                    Relax(u, v.TargetNode);
                }
            }
        }

        public void BellmanFord(GraphNode s)
        {
            foreach (var v in Graph.AdjacencyList.Where(o => o.Index != s.Index))
            {
                Shortest[v.Index] = double.PositiveInfinity;
            }

            for (int i = 1; i < Graph.AdjacencyList.Count; i++)
            {
                foreach (var u in Graph.AdjacencyList)
                {
                    foreach (var v in u.Adjacencies)
                {
                    Relax(u, v.TargetNode);
                }
                }
            }
        }
    }
}
