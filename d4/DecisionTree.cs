using System;
using System.Collections.Generic;
using System.Linq;

namespace d4
{
    public class DecisionTree
    {
        // BuildTree method to construct the decision tree
        public static TreeNode BuildTree(List<DataPoint> data, List<string> attributes, int maxDepth, int minSize, int depth = 0)
        {
            if (data.Count <= minSize || depth >= maxDepth)
            {
                var label = data.GroupBy(d => d.Label).OrderByDescending(g => g.Count()).First().Key;
                Console.WriteLine($"Depth: {depth}, Label: {label}");
                return new TreeNode { Label = label };
            }

            // Find the best split based on the Gini index
            var (feature, threshold, gini, left, right) = GiniIndex.FindBestSplit(data, attributes);
            Console.WriteLine($"Depth: {depth}, Attribute: {feature}, Value: {threshold}, Gini: {gini}");

            // If no split is found, return a leaf node with the majority label
            if (left.Count == 0 || right.Count == 0)
            {
                var label = data.GroupBy(d => d.Label).OrderByDescending(g => g.Count()).First().Key;
                Console.WriteLine($"Depth: {depth}, Label: {label}");
                return new TreeNode { Label = label };
            }

            // Recursively build the left and right subtrees
            var leftNode = BuildTree(left, attributes, maxDepth, minSize, depth + 1);
            var rightNode = BuildTree(right, attributes, maxDepth, minSize, depth + 1);

            // Return the current node with the best Attribute and threshold
            return new TreeNode
            {
                Attribute = feature,
                Threshold = threshold,
                Left = leftNode,
                Right = rightNode
            };
        }


        // Predict method to classify a data point using the decision tree
        public static string Predict(TreeNode node, DataPoint dataPoint)
        {
            // If the node is a leaf, return its label
            if (node.Label != null)
            {
                return node.Label;
            }

            // Traverse the tree based on the attribute value
            if (dataPoint.Attributes[node.Attribute] == node.Threshold)
            {
                return Predict(node.Left, dataPoint);
            }
            else
            {
                return Predict(node.Right, dataPoint);
            }
        }
    }
}
