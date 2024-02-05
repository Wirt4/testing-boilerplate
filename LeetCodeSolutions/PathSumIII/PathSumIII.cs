namespace LeetCodeSolutions;
public class PathSumIIISolution
{

    private class TreeWrapper(int targetSum)
    {
        private readonly int _targetSum = targetSum;

        private int RecursiveSum(TreeNode node, int parentSum = 0)
        {
            int leftSums = NumberOfTargetSums(node.left, parentSum);
            int rightSums = NumberOfTargetSums(node.right, parentSum);
            return leftSums + rightSums;
        }

        public int NumberOfTargetSums(TreeNode node, int runningSum = 0)
        {
            if (node == null)
            {
                return 0;
            }

            runningSum += node.val;
            int sumsFromCurrent = RecursiveSum(node);
            sumsFromCurrent += runningSum == _targetSum ? 1 : RecursiveSum(node, runningSum);
            return sumsFromCurrent;
        }
    }
    public int PathSum(TreeNode root, int targetSum)
    {
        TreeWrapper tree = new(targetSum);
        return tree.NumberOfTargetSums(root);
    }
}
