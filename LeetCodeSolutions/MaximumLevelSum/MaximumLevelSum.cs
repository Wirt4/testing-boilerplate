namespace LeetCodeSolutions;
public class MaximumLevelSumSolution
{
    public int MaxLevelSum(TreeNode root)
    {
        int maxLevel = 1;
        int currentLevel = 1;
        int highestSum = root.val;
        int currentSum = 0;
        Stack<TreeNode> currentTier = new();
        currentTier.Push(root);
        Stack<TreeNode> nextTier = new();

        while (currentTier.Count > 0)
        {
            TreeNode node = currentTier.Pop();
            currentSum += node.val;

            if (node.left != null)
            {
                nextTier.Push(node.left);
            }

            if (node.right != null)
            {
                nextTier.Push(node.right);
            }

            if (currentTier.Count == 0)
            {
                if (currentSum > highestSum)
                {
                    maxLevel = currentLevel;
                    highestSum = currentSum;
                }

                currentSum = 0;
                currentLevel++;
                currentTier = nextTier;
                nextTier = new();
            }
        }

        return maxLevel;
    }
}
