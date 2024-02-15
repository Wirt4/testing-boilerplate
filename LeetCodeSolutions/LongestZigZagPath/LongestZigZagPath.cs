namespace LeetCodeSolutions;
public class LongestZigZagPathSolution
{
    private class Paths
    {
        public int Left;
        public int Right;
        public Paths(int left = 0, int right = 0)
        {
            Left = left;
            Right = right;
        }

        public int Longest => Math.Max(Left, Right);

        public Paths ShiftLeft()
        {
            return new Paths(0, Left + 1);
        }

        public Paths ShiftRight()
        {
            return new Paths(Right + 1, 0);
        }
    }

    private class TreeNavigator
    {
        public int LongestPath;
        public TreeNavigator()
        {
            LongestPath = 0;
        }

        public int LongestZigZagPath(TreeNode root)
        {
            RecursiveTraverse(root, new Paths());
            return LongestPath;
        }

        private void RecursiveTraverse(TreeNode? node, Paths paths)
        {
            if (node == null) return;

            LongestPath = Math.Max(LongestPath, paths.Longest);
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