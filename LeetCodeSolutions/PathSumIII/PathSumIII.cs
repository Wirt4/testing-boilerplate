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
        private void Lookup(int sum)
        {
            if (_frequencyOfSums.TryGetValue(sum, out int value))
            {
                _numberOfMatchingPaths += value;
            }
        }
        private void Add(int sum)
        {
            if (_frequencyOfSums.TryGetValue(sum, out int value))
            {
                _frequencyOfSums[sum] = ++value;
                return;
            }
            _frequencyOfSums.Add(sum, 1);

        }
        private void TraverseMemoized(TreeNode node, int currentPathSum)
        {
            if (node == null)
            {
                return;
            }

            currentPathSum += node.val;
            Lookup(currentPathSum - _targetSum);
            Add(currentPathSum);
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
