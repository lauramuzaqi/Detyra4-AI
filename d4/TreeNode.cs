namespace d4
{
    public class TreeNode
    {
        // TreeNode class representing a node in the decision tree
        public string Attribute { get; set; }
        public string Threshold { get; set; }
        public TreeNode Left { get; set; }
        public TreeNode Right { get; set; }
        public string Label { get; set; }
    }
}
