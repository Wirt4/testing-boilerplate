namespace LeetCodeSolutions;
public class PathSumIIISolution
{
    private int RecursiveCall(TreeNode node, int targetSum, int currentSum = 0)
    {
        return PathSum(node.left, targetSum) + PathSum(node.right, targetSum, currentSum);
    }

    public int PathSum(TreeNode root, int targetSum, int currentSum = 0)
    {
        //base case
        if (root != null)
        {
            if (root.val == targetSum || root.val + currentSum == targetSum)
            {
                return 1 + RecursiveCall(root, targetSum);
            }
            if (currentSum == 0)
            {
                return RecursiveCall(root, targetSum) + RecursiveCall(root, targetSum, root.val);
            }
            return RecursiveCall(root, targetSum) + RecursiveCall(root, targetSum, root.val) + RecursiveCall(root, targetSum, root.val + currentSum);
        }
        return 0;
    }
}
