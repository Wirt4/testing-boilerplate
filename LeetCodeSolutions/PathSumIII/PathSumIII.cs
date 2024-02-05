namespace LeetCodeSolutions;
public class PathSumIIISolution
{
    private class TreeSearcher
    {
        private int _numberOfMatchingPaths;
        private readonly Dictionary<int, int> _frequencyOfSums;
        public TreeSearcher()
        {
            _numberOfMatchingPaths = 0;
            _frequencyOfSums = new()
            {
                { 0, 1 }
            };
        }
        public int NumberOfPaths => _numberOfMatchingPaths;
        private void TraverseMemoized(TreeNode node, int targetSum, int currentPathSum)
        {
            if (node == null)
            {
                return;
            }
            currentPathSum += node.val;
            int oldPathSum = currentPathSum - targetSum;
            if (_frequencyOfSums.TryGetValue(oldPathSum, out int oldValue))
            {
                _numberOfMatchingPaths += oldValue;
            }

            if (_frequencyOfSums.TryGetValue(currentPathSum, out int newValue))
            {
                _frequencyOfSums[currentPathSum] = ++newValue;
            }
            else
            {
                _frequencyOfSums.Add(currentPathSum, 1);
            }

            TraverseMemoized(node.left, targetSum, currentPathSum);
            TraverseMemoized(node.right, targetSum, currentPathSum);

            _frequencyOfSums[currentPathSum]--;
        }
        public void TraverseTree(TreeNode node, int targetSum)
        {
            TraverseMemoized(node, targetSum, 0);
        }
    }
    public int PathSum(TreeNode root, int targetSum)
    {
        TreeSearcher searchWrapper = new();
        searchWrapper.TraverseTree(root, targetSum);
        return searchWrapper.NumberOfPaths;
    }
}
