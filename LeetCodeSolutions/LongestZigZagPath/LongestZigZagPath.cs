namespace LeetCodeSolutions;
public class LongestZigZagPathSolution
{



    public int LongestZigZag(TreeNode? root, int length = 0, bool isLeft = true)
    {
        if (root == null || (root.left == null && root.right == null)) return length;
        int newLength = length + 1;
        if (isLeft)
        {
            if (root.left != null) return LongestZigZag(root.left, newLength, false);
        }

        if (root.right != null) return LongestZigZag(root.right, newLength, true);

        return length;
    }
}
