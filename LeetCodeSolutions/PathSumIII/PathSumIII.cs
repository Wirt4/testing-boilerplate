namespace LeetCodeSolutions;
public class PathSumIIISolution
{
    private class TreeSearcher
    {
        private int _numberOfMatchingPaths;
        private readonly Dictionary<int, int> _frequencyOfSums;
        private readonly int _targetSum;
        public TreeSearcher(int targetSum)
        {
            _targetSum = targetSum;
            _numberOfMatchingPaths = 0;
            _frequencyOfSums = new()
            {
                { 0, 1 }
            };
        }
        public int NumberOfPaths => _numberOfMatchingPaths;
        private void TraverseMemoized(TreeNode node, int currentPathSum)
        {
            if (node == null)
            {
                return;
            }

            currentPathSum += node.val;
            int oldPathSum = currentPathSum - _targetSum;
            //lookup sum
            if (_frequencyOfSums.TryGetValue(oldPathSum, out int oldValue))
            {
                _numberOfMatchingPaths += oldValue;
            }
            //add sum
            if (_frequencyOfSums.TryGetValue(currentPathSum, out int newValue))
            {
                _frequencyOfSums[currentPathSum] = ++newValue;
            }
            else
            {
                _frequencyOfSums.Add(currentPathSum, 1);
            }

            TraverseMemoized(node.left, currentPathSum);
            TraverseMemoized(node.right, currentPathSum);

            _frequencyOfSums[currentPathSum]--;
        }
        public void TraverseTree(TreeNode node)
        {
            TraverseMemoized(node, 0);
        }
    }
    public int PathSum(TreeNode root, int targetSum)
    {
        TreeSearcher searchWrapper = new(targetSum);
        searchWrapper.TraverseTree(root);
        return searchWrapper.NumberOfPaths;
    }
}
