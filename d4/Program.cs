using System;
using System.Collections.Generic;

namespace d4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Creating a list of DataPoint objects with attribute values and results of class attr.
            var data = new List<DataPoint>
            {
                new DataPoint { Attributes = new Dictionary<string, string> { { "Dhimbje Fyti", "Po" }, { "Ethe", "Po" }, { "Gjendra te fryera", "Po" }, { "Bllokim", "Po" }, { "Dhimbje koke", "Po" } }, Label = "Fyt i pezmatuar" },
                new DataPoint { Attributes = new Dictionary<string, string> { { "Dhimbje Fyti", "Jo" }, { "Ethe", "Jo" }, { "Gjendra te fryera", "Jo" }, { "Bllokim", "Po" }, { "Dhimbje koke", "Po" } }, Label = "Alergji" },
                new DataPoint { Attributes = new Dictionary<string, string> { { "Dhimbje Fyti", "Po" }, { "Ethe", "Po" }, { "Gjendra te fryera", "Jo" }, { "Bllokim", "Po" }, { "Dhimbje koke", "Jo" } }, Label = "Ftohje" },
                new DataPoint { Attributes = new Dictionary<string, string> { { "Dhimbje Fyti", "Po" }, { "Ethe", "Jo" }, { "Gjendra te fryera", "Po" }, { "Bllokim", "Jo" }, { "Dhimbje koke", "Jo" } }, Label = "Fyt i pezmatuar" },
                new DataPoint { Attributes = new Dictionary<string, string> { { "Dhimbje Fyti", "Jo" }, { "Ethe", "Po" }, { "Gjendra te fryera", "Jo" }, { "Bllokim", "Po" }, { "Dhimbje koke", "Jo" } }, Label = "Ftohje" },
                new DataPoint { Attributes = new Dictionary<string, string> { { "Dhimbje Fyti", "Jo" }, { "Ethe", "Jo" }, { "Gjendra te fryera", "Jo" }, { "Bllokim", "Po" }, { "Dhimbje koke", "Jo" } }, Label = "Alergji" },
                new DataPoint { Attributes = new Dictionary<string, string> { { "Dhimbje Fyti", "Jo" }, { "Ethe", "Jo" }, { "Gjendra te fryera", "Po" }, { "Bllokim", "Jo" }, { "Dhimbje koke", "Jo" } }, Label = "Fyt i pezmatuar" },
                new DataPoint { Attributes = new Dictionary<string, string> { { "Dhimbje Fyti", "Po" }, { "Ethe", "Jo" }, { "Gjendra te fryera", "Jo" }, { "Bllokim", "Po" }, { "Dhimbje koke", "Po" } }, Label = "Alergji" },
                new DataPoint { Attributes = new Dictionary<string, string> { { "Dhimbje Fyti", "Jo" }, { "Ethe", "Po" }, { "Gjendra te fryera", "Jo" }, { "Bllokim", "Po" }, { "Dhimbje koke", "Po" } }, Label = "Ftohje" },
                new DataPoint { Attributes = new Dictionary<string, string> { { "Dhimbje Fyti", "Po" }, { "Ethe", "Jo" }, { "Gjendra te fryera", "Jo" }, { "Bllokim", "Po" }, { "Dhimbje koke", "Po" } }, Label = "Ftohje" }
            };

            // Defining the features to be used in the decision tree
            var attributes = new List<string> { "Dhimbje Fyti", "Ethe", "Gjendra te fryera", "Bllokim", "Dhimbje koke" };

            // Building the decision tree using the data, features, maximum depth, and minimum size
            var tree = DecisionTree.BuildTree(data, attributes, maxDepth: 3, minSize: 1);

            // Creating new records
            var record1 = new DataPoint { Attributes = new Dictionary<string, string> { { "Dhimbje Fyti", "Po" }, { "Ethe", "Jo" }, { "Gjendra te fryera", "Po" }, { "Bllokim", "Po" }, { "Dhimbje koke", "Po" } } };
            var prediction1 = DecisionTree.Predict(tree, record1);

            // Printing predictions for the test points
            Console.WriteLine($"Prediction 1: {prediction1}");   //fyt i pezmetuar
        }
    }
}
