
namespace TreeManipulation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Tree
    {
        static void Main(string[] args)
        {
            var N = int.Parse(Console.ReadLine());
            var treeNodes = new TreeNode<int>[N];

            for (int i = 0; i < N; i++)
            {
                treeNodes[i] = new TreeNode<int>(i);
            }

            for (int i = 1; i <= N - 1; i++)
            {
                string edgeAsString = Console.ReadLine();
                var edgeNodes = edgeAsString.Split(' ');

                int parentId = int.Parse(edgeNodes[0]);
                int childId = int.Parse(edgeNodes[1]);

                treeNodes[parentId].Children.Add(treeNodes[childId]);
                treeNodes[childId].HasParent = true;
            }

            #region 1. Find the root

            var root = FindRoot(treeNodes);
            Console.WriteLine("The root of the tree is: {0}", root.Value);

            #endregion

            #region 2. Find all leafs

            var leafs = FindAllLeafs(treeNodes);
            Console.Write("Leafs: ");
            foreach (var leaf in leafs)
            {
                Console.Write("{0}, ", leaf.Value);
            }
            Console.WriteLine();

            #endregion

            #region 3. Find all middle TreeNodes

            var middleTreeNodes = FindAllMiddleTreeNodes(treeNodes);
            Console.Write("Middle TreeNodes: ");
            foreach (var TreeNode in middleTreeNodes)
            {
                Console.Write("{0}, ", TreeNode.Value);
            }
            Console.WriteLine();

            #endregion

            #region 4. Find the longest path from the root

            var longestPath = FindLongestPath(root);
            Console.WriteLine("Longest path has {0} levels.", longestPath + 1);

            #endregion

            #region 5. Find all paths in the tree with given sum S of their nodes

            var sum = 9;
            Console.WriteLine("All paths with sum ({0}) are: ", sum);
            FindAllPathsWithGivenSumS(root, sum, root.Value, root.Value.ToString());

            #endregion

            #region 6. Find all subtrees with given sum S of their TreeNode

            var sum1 = 12;
            Console.WriteLine("All subtrees with sum ({0}) are: ", sum1);
            FindAllSubtreesWithGivenSumS(root, sum1); 

            #endregion
        }

        static TreeNode<int> FindRoot(TreeNode<int>[] TreeNodes)
        {
            var hasParent = new bool[TreeNodes.Length];

            foreach (var TreeNode in TreeNodes)
            {
                foreach (var child in TreeNode.Children)
                {
                    hasParent[child.Value] = true;
                }
            }

            for (int i = 0; i < hasParent.Length; i++)
            {
                if (!hasParent[i])
                {
                    return TreeNodes[i];
                }
            }

            throw new ArgumentException("TreeNodes", "The tree has no root.");
        }

        private static List<TreeNode<int>> FindAllLeafs(TreeNode<int>[] TreeNodes)
        {
            List<TreeNode<int>> leafs = new List<TreeNode<int>>();

            foreach (var TreeNode in TreeNodes)
            {
                if (TreeNode.Children.Count == 0)
                {
                    leafs.Add(TreeNode);
                }
            }

            return leafs;
        }

        private static List<TreeNode<int>> FindAllMiddleTreeNodes(TreeNode<int>[] TreeNodes)
        {
            List<TreeNode<int>> middleTreeNodes = new List<TreeNode<int>>();

            foreach (var TreeNode in TreeNodes)
            {
                if (TreeNode.HasParent && TreeNode.Children.Count > 0)
                {
                    middleTreeNodes.Add(TreeNode);
                }
            }

            return middleTreeNodes;
        }

        private static int FindLongestPath(TreeNode<int> root)
        {
            if (root.Children.Count == 0)
            {
                return 0;
            }

            int maxPath = 0;
            foreach (var treeNode in root.Children)
            {
                maxPath = Math.Max(maxPath, FindLongestPath(treeNode));
            }

            return maxPath + 1;
        }

        private static void FindAllPathsWithGivenSumS(TreeNode<int> root, int sum, int currentSum, string path)
        {
            if (sum == currentSum)
            {
                Console.WriteLine(path);
            }
            else
            {
                foreach (var child in root.Children)
                {
                    FindAllPathsWithGivenSumS(child, sum, currentSum + child.Value, path + " -> " + child.Value);
                }
            }
        }

        private static void FindAllSubtreesWithGivenSumS(TreeNode<int> root, int sum)
        {
            Stack<TreeNode<int>> stack = new Stack<TreeNode<int>>();
            stack.Push(root);

            while (stack.Count > 0)
            {
                TreeNode<int> treeNode = stack.Pop();
                foreach (var child in treeNode.Children)
                {
                    stack.Push(child);
                    List<int> result = new List<int>();
                    GetSubtreeNodes(child, result);
                    if (result.Sum() == sum)
                    {
                        Console.WriteLine(string.Join("-> ", result));
                    }
                }
            }
        }

        private static void GetSubtreeNodes(TreeNode<int> treeNode, List<int> result)
        {
            result.Add(treeNode.Value);
            foreach (var child in treeNode.Children)
            {
                GetSubtreeNodes(child, result);
            }
        }
    }
}
