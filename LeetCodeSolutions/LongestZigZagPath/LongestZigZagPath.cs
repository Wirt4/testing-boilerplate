namespace LeetCodeSolutions;
public class LongestZigZagPathSolution
{
    private class Paths
    {
        public int Left;
        public int Right;
        public Paths(int left, int right)
        {
            Left = left;
            Right = right;
        }

        public int Longest => Math.Max(Left, Right);
    }

    private class TreeNavigator
    {
        public int LongestPath;
        public TreeNavigator()
        {
            LongestPath = 0;
        }

        public void Traverse(TreeNode root)
        {
            RecursiveTraverse(root, new Paths(0, 0));
        }

        private void RecursiveTraverse(TreeNode? node, Paths paths)
        {
            if (node == null) return;
            LongestPath = Math.Max(LongestPath, paths.Longest);
            RecursiveTraverse(node.left, new Paths(0, paths.Left + 1));
            RecursiveTraverse(node.right, new Paths(paths.Right + 1, 0));
        }
    }
    public int LongestZigZag(TreeNode root)
    {
        TreeNavigator treeNav = new();
        treeNav.Traverse(root);
        return treeNav.LongestPath;
    }
}