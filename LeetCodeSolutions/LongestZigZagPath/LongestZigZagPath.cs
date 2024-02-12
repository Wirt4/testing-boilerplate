namespace LeetCodeSolutions;
public class LongestZigZagPathSolution
{



    public int LongestZigZag(TreeNode? root)
    {
        if (root == null) return 0;
        if (root.left == null && root.right == null) { return 0; }
        return 1;
    }
}
