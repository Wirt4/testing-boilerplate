namespace LeetCodeSolutions;
public class PathSumSolution
{
    private static bool IsBaseCase(TreeNode? node)
    {
        return node == null;
    }

    private static bool IsEndLeaf(TreeNode node)
    {
        return IsBaseCase(node.left) && IsBaseCase(node.right);
    }

    private bool RecursiveCall(TreeNode node, int targetSum, int runningSum)
    {
        if (HasPathSum(node.left, targetSum, runningSum))
        {
            return true;
        }

        return HasPathSum(node.right, targetSum, runningSum);
    }
    public bool HasPathSum(TreeNode root, int targetSum, int runningSum = 0)
    {
        if (IsBaseCase(root))
        {
            return false;
        }

        runningSum += root.val;

        if (IsEndLeaf(root))
        {
            return targetSum == runningSum;
        }

        return RecursiveCall(root, targetSum, runningSum);

    }
}
