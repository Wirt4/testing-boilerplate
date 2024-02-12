namespace LeetCodeSolutions;
public class LongestZigZagPathSolution
{



    public int LongestZigZag(TreeNode? root, int length = 0, bool isLeft = true)
    {
        if (root == null || (root.left == null && root.right == null)) return length;
        if (isLeft)
        {
            if (root.left != null) return LongestZigZag(root.left, length + 1, false);
        }
        else
        {
            if (root.right != null) return LongestZigZag(root.right, length + 1, true);
        }
        return length;
    }
}
