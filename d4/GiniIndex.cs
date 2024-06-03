using System.Collections.Generic;
using System.Linq;

namespace d4
{
    public class GiniIndex
    {
        //the method to calculate the Gini impurity
        public static double GiniImpurity(List<DataPoint> data)
        {
            var totalCount = data.Count;
            var labelCounts = data.GroupBy(d => d.Label).Select(g => g.Count()).ToList();

            double impurity = 1.0;
            foreach (var count in labelCounts)
            {
                var prob = count / (double)totalCount;
                impurity -= prob * prob;
            }

            return impurity;
        }

        // SplitData method to split the dataset based on a attribute and threshold
        public static (List<DataPoint> left, List<DataPoint> right) SplitData(List<DataPoint> data, string attribute, string threshold)
        {
            var left = new List<DataPoint>();
            var right = new List<DataPoint>();

            foreach (var point in data)
            {
                if (point.Attributes[attribute] == threshold)
                {
                    left.Add(point);
                }
                else
                {
                    right.Add(point);
                }
            }

            return (left, right);
        }
        // FindBestSplit method to find the best attribute and threshold to split the data
        public static (string bestAttribute, string bestThreshold, double bestGini, List<DataPoint> left, List<DataPoint> right) FindBestSplit(List<DataPoint> data, List<string> attributes)
        {
            double bestGini = double.MaxValue;
            string bestAttribute = null;
            string bestThreshold = null;
            List<DataPoint> bestLeft = null;
            List<DataPoint> bestRight = null;

            foreach (var attr in attributes)  // Iterate over each attribute to find the best split
            {
                var thresholds = data.Select(d => d.Attributes[attr]).Distinct().ToList();
                foreach (var threshold in thresholds)
                {
                    var (left, right) = SplitData(data, attr, threshold);
                    if (left.Count == 0 || right.Count == 0)
                        continue;

                    var gini = (left.Count * GiniImpurity(left) + right.Count * GiniImpurity(right)) / data.Count;

                    if (gini < bestGini)
                    {
                        bestGini = gini;
                        bestAttribute = attr;
                        bestThreshold = threshold;
                        bestLeft = left;
                        bestRight = right;
                    }
                }
            }

            return (bestAttribute, bestThreshold, bestGini, bestLeft, bestRight);
        }

    }
}
