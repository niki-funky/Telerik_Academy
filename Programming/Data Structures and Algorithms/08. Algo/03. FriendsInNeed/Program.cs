using System;
using System.Collections.Generic;
using System.Linq;
using Wintellect.PowerCollections;

namespace _03.FriendsInNeed
{
    struct Node : IComparable<Node>
    {
        public int Next { get; set; }
        public int Distance { get; set; }

        public Node(int vertex, int distance)
            : this()
        {
            this.Next = vertex;
            this.Distance = distance;
        }

        public int CompareTo(Node obj)
        {
            return this.Distance.CompareTo(obj.Distance);
        }
    }

    class Program
    {
        static int n;
        static int m;
        static int h;
        static int[] distance;
        static IList<IList<Node>> graph = null;

        public static void Dijkstra(int start)
        {
            for (int i = 0; i < graph.Count; i++)
            {
                distance[i] = int.MaxValue;
            }

            var queue = new OrderedBag<Node>();
            queue.Add(new Node(start, 0));

            distance[start] = 0;

            while (queue.Count != 0)
            {
                var minNode = queue.RemoveFirst();

                foreach (var node in graph[minNode.Next])
                {
                    int currentDistance = distance[minNode.Next] + node.Distance;

                    if (currentDistance < distance[node.Next])
                    {
                        distance[node.Next] = currentDistance;
                        queue.Add(new Node(node.Next, currentDistance));
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

            #region parse input
            string[] items = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            n = int.Parse(items[0]);
            m = int.Parse(items[1]);
            h = int.Parse(items[2]);

            distance = new int[n];

            graph = new List<IList<Node>>();
            for (int i = 0; i < n; i++)
            {
                graph.Add(new List<Node>());
            }

            int[] hospitals = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();

            for (int i = 0; i < m; i++)
            {
                string[] streets = Console.ReadLine().Split(' ');
                int p1 = int.Parse(streets[0]);
                int p2 = int.Parse(streets[1]);
                int dist = int.Parse(streets[2]);

                graph[p1 - 1].Add(new Node(p2 - 1, dist));
                graph[p2 - 1].Add(new Node(p1 - 1, dist));
            }
            #endregion

            int smallestDistance = int.MaxValue;

            for (int i = 0; i < hospitals.Length; i++)
            {
                Dijkstra(hospitals[i] - 1);

                int currentDistance = distance.Where((dist, k) => !hospitals.Contains(k + 1)).Sum();

                if (currentDistance < smallestDistance)
                {
                    smallestDistance = currentDistance;
                }
            }

            Console.WriteLine(smallestDistance);

#if DEBUG
            Console.WriteLine(DateTime.Now - date);
#endif
        }
    }
}