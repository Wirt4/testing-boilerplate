namespace LeetCodeSolutions;
public class LongestZigZagPathSolution
{
    private class Paths
    {
        private readonly int _left;
        private readonly int _right;
        public Paths(int left = 0, int right = 0)
        {
            _left = left;
            _right = right;
        }

        public int Longest => Math.Max(_left, _right);

        public Paths ShiftLeft()
        {
            return new Paths(0, _left + 1);
        }

        public Paths ShiftRight()
        {
            return new Paths(_right + 1, 0);
        }
    }

    private class TreeNavigator
    {
        private int _longestPath;
        public TreeNavigator()
        {
            _longestPath = 0;
        }

        public int LongestZigZagPath(TreeNode root)
        {
            RecursiveTraverse(root, new Paths());
            return _longestPath;
        }

        private void RecursiveTraverse(TreeNode? node, Paths paths)
        {
            if (node == null) return;

            _longestPath = Math.Max(_longestPath, paths.Longest);
            RecursiveTraverse(node.left, paths.ShiftLeft());
            RecursiveTraverse(node.right, paths.ShiftRight());
        }
    }
    public int LongestZigZag(TreeNode root)
    {
        TreeNavigator treeNav = new();
        return treeNav.LongestZigZagPath(root);
    }
}