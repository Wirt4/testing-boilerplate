using System.Runtime.InteropServices;

namespace LeetCodeSolutions;
public class PathSumIIISolution
{
    private class TreeSearcher(int targetSum)
    {
        private int _numberOfMatchingPaths = 0;
        private readonly long _targetSum = targetSum;
        private readonly Dictionary<long, int> _frequencyOfSums = BaseCase();

        private static Dictionary<long, int> BaseCase()
        {
            return new()
            {
                { 0, 1 }
            };
        }
        private int LookUpExistingAnswer(long sum)
        {
            if (_frequencyOfSums.TryGetValue(sum, out int value))
            {
                return value;
            }

            return -1;
        }
        private void Add(long sum)
        {
            if (_frequencyOfSums.TryGetValue(sum, out int value))
            {
                _frequencyOfSums[sum] = ++value;
                return;
            }

            _frequencyOfSums.Add(sum, 1);

        }
        private void Remove(long sum)
        {
            _frequencyOfSums[sum]--;
        }
        private void TraverseMemoized(TreeNode node, long currentPathSum)
        {
            if (node == null)
            {
                return;
            }

            currentPathSum += node.val;
            int lookupValue = LookUpExistingAnswer(currentPathSum - _targetSum);

            if (lookupValue > 0)
            {
                _numberOfMatchingPaths += lookupValue;
            }

            Add(currentPathSum);
            TraverseMemoized(node.left, currentPathSum);
            TraverseMemoized(node.right, currentPathSum);
            Remove(currentPathSum);
        }
        public int NumberOfPaths => _numberOfMatchingPaths;
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
