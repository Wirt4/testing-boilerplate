namespace LeetCodeSolutions;
public class PathSumIIISolution
{
    public int PathSum(TreeNode root, int targetSum, int parentSum = 0)
    {
        if (root == null)
        {
            return 0;
        }

        int currentVal = root.val + parentSum;
        int sumFromCur = PathSum(root.left, targetSum) + PathSum(root.right, targetSum);

        if (currentVal > targetSum)
        {
            return sumFromCur;
        }

        if (currentVal == targetSum)
        {
            return 1 + sumFromCur;
        }

        return sumFromCur + PathSum(root.left, targetSum, currentVal) + PathSum(root.right, targetSum, currentVal);

    }
}
