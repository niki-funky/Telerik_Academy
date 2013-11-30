using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.CableCompany
{
    class Edge : IComparable<Edge>
    {
        public int StartNode { get; set; }
        public int EndNode { get; set; }
        public int Weight { get; set; }

        public Edge(int startNode, int endNode, int weight)
        {
            this.StartNode = startNode;
            this.EndNode = endNode;
            this.Weight = weight;
        }

        public int CompareTo(Edge other)
        {
            int weightCompared = this.Weight.CompareTo(other.Weight);

            if (weightCompared == 0)
            {
                return this.StartNode.CompareTo(other.StartNode);
            }
            return weightCompared;
        }
    }

    class Program
    {
        // using Kruskal's algorithm
        private static void FindMinimumSpanningTree(
            List<Edge> edges, int[] tree, List<Edge> mpd, int treesCount)
        {
            foreach (var edge in edges)
            {
                if (tree[edge.StartNode] == 0) // not visited
                {
                    if (tree[edge.EndNode] == 0) // both ends are not visited
                    {
                        tree[edge.StartNode] = tree[edge.EndNode] = treesCount;
                        treesCount++;
                    }
                    else
                    {
                        // attach the start node to the tree of the end node
                        tree[edge.StartNode] = tree[edge.EndNode];
                    }
                    mpd.Add(edge);
                }
                else // the start is part of a tree
                {
                    if (tree[edge.EndNode] == 0)
                    {
                        //attach the end node to the tree;
                        tree[edge.EndNode] = tree[edge.StartNode];
                        mpd.Add(edge);
                    }
                    else if (tree[edge.EndNode] != tree[edge.StartNode]) // combine the trees
                    {
                        int oldTreeNumber = tree[edge.EndNode];

                        for (int i = 0; i < tree.Length; i++)
                        {
                            if (tree[i] == oldTreeNumber)
                            {
                                tree[i] = tree[edge.StartNode];
                            }
                        }
                        mpd.Add(edge);
                    }
                }
            }
        }

        public static void Main()
        {
#if DEBUG
            Console.SetIn(new System.IO.StreamReader("../../input.txt"));
#endif
            var date = DateTime.Now;

            int n = int.Parse(Console.ReadLine());
            List<Edge> edges = new List<Edge>();

            for (int i = 0; i < n; i++)
            {
                string[] houses = Console.ReadLine().Split(new char[] { ' ' },
                    StringSplitOptions.RemoveEmptyEntries);
                int p1 = int.Parse(houses[0]);
                int p2 = int.Parse(houses[1]);
                int dist = int.Parse(houses[2]);

                edges.Add(new Edge(p1, p2, dist));
            }

            edges.Sort();

            int[] tree = new int[n + 1];
            List<Edge> usedEdges = new List<Edge>();

            FindMinimumSpanningTree(edges, tree, usedEdges, 1);

            Console.WriteLine(usedEdges.Sum(x => x.Weight));
            // answer must be 16

#if DEBUG
            Console.WriteLine(DateTime.Now - date);
#endif
        }
    }
}