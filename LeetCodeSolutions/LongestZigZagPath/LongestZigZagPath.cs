namespace LeetCodeSolutions;
public class LongestZigZagPathSolution
{
    public int LongestZigZag(TreeNode root, int left = 0, int right = 0)
    {
        if (root != null)
        {
            left = LongestZigZag(root.left, 0, left + 1);
            right = LongestZigZag(root.right, right + 1, left);
        }
        return Math.Max(left, right);
    }
}
