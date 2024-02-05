namespace LeetCodeSolutions;
public class LongestZigZagPathSolution
{
    private enum Direction
    {
        Left,
        Right
    }
    private int TraverseTree(TreeNode node, int longestZigZag)
    {
        if (node == null)
        {
            return longestZigZag;
        }
        int left = MaxZigZag(node, Direction.Left);
        int right = MaxZigZag(node, Direction.Right);
        int longestFromNode = left > right ? left : right;
        if (longestFromNode > longestZigZag)
        {
            longestZigZag = longestFromNode;
        }
        int leftTraversal = TraverseTree(node.left, longestZigZag);
        int rightTraversal = TraverseTree(node.right, longestZigZag);
        return leftTraversal > rightTraversal ? leftTraversal : rightTraversal;
    }
    public int LongestZigZag(TreeNode root)
    {
        return TraverseTree(root, 0);
    }

    private int MaxZigZag(TreeNode node, Direction direction)
    {
        if (node == null)
        {
            return 0;
        }

        if (direction == Direction.Left && node.left == null)
        {
            return 0;
        }

        if (direction == Direction.Right && node.right == null)
        {
            return 0;
        }

        if (direction == Direction.Left)
        {
            return 1 + MaxZigZag(node.left, Direction.Right);
        }

        if (direction == Direction.Right)
        {
            return 1 + MaxZigZag(node.right, Direction.Left);
        }
        return -1;
    }
}
