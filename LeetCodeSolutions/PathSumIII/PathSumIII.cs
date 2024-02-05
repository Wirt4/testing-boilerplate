namespace LeetCodeSolutions;
public class PathSumIIISolution
{
    private enum Comparison
    {
        Equal,
        GreaterThan,
        LessThan
    }
    private class TreeWrapper(int targetSum)
    {
        private readonly int _targetSum = targetSum;

        private Comparison CompareValues(int currentVal)
        {
            if (currentVal > _targetSum) return Comparison.GreaterThan;

            if (currentVal == _targetSum) return Comparison.Equal;

            return Comparison.LessThan;
        }

        private int RecursiveSum(TreeNode node, int parentSum = 0)
        {
            return NumberOfTargetSums(node.left, parentSum) + NumberOfTargetSums(node.right, parentSum);
        }

        public int NumberOfTargetSums(TreeNode node, int parentSum = 0)
        {
            if (node == null) return 0;

            int currentVal = node.val + parentSum;
            int sumsFromCurrent = RecursiveSum(node);

            return CompareValues(currentVal) switch
            {
                Comparison.GreaterThan => sumsFromCurrent,
                Comparison.Equal => sumsFromCurrent + 1,
                _ => sumsFromCurrent + RecursiveSum(node, currentVal),
            };
        }
    }
    public int PathSum(TreeNode root, int targetSum)
    {
        TreeWrapper tree = new(targetSum);
        return tree.NumberOfTargetSums(root);
    }
}
