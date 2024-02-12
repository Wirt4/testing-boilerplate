namespace LeetCodeSolutions;
public class LongestZigZagPathSolution
{
    private void Traverse(TreeNode node, ref int longestPath, int leftPath, int rightPath)
    {
        if (node == null) return;
        longestPath = Math.Max(longestPath, Math.Max(leftPath, rightPath));
        Traverse(node.left, ref longestPath, 0, leftPath + 1);
        Traverse(node.right, ref longestPath, rightPath + 1, 0);
    }
    public int LongestZigZag(TreeNode root)
    {
        int longestZigZag = 0;
        Traverse(root, ref longestZigZag, 0, 0);
        return longestZigZag;
    }
}