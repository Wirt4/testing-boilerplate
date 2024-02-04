namespace LeetCodeSolutions;
public class MaxDepthOfBinaryTreeSolution
{
    public int MaxDepth(TreeNode root)
    {
        if (root == null)
        {
            return 0;
        }

        int leftDepth = MaxDepth(root.left);
        int rightDepth = MaxDepth(root.right);
        int max = leftDepth > rightDepth ? leftDepth : rightDepth;
        return 1 + max;
    }
}
