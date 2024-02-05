namespace LeetCodeSolutions;
public class LongestZigZagPathSolution
{
    private class TreeWrapper
    {
        private int _longestPath;
        public int LongestPath => _longestPath;
        public TreeWrapper()
        {
            _longestPath = 0;
        }
        private void DepthFirstTraverse(TreeNode node, int leftPathLength, int rightPathLength)
        {
            if (node == null)
            {
                return;
            }

            _longestPath = Math.Max(_longestPath, Math.Max(leftPathLength, rightPathLength));
            DepthFirstTraverse(node.left, 0, leftPathLength + 1);
            DepthFirstTraverse(node.right, rightPathLength + 1, 0);
        }
        public void TraverseTree(TreeNode root)
        {
            DepthFirstTraverse(root, 0, 0);
        }
    }
    public int LongestZigZag(TreeNode root)
    {
        TreeWrapper wrapper = new();
        wrapper.TraverseTree(root);
        return wrapper.LongestPath; ;
    }
}
