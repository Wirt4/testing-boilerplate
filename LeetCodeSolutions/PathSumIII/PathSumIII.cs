using System.Reflection.PortableExecutable;

namespace LeetCodeSolutions;
public class PathSumIIISolution
{
    private class TreeSearcher
    {
        private int _numberOfMatchingPaths;
        private readonly Dictionary<long, int> _frequencyOfSums;
        private readonly long _targetSum;
        public TreeSearcher(int targetSum)
        {
            _targetSum = targetSum;
            _numberOfMatchingPaths = 0;
            //there is always one path of sum zero, the null set so to speak
            _frequencyOfSums = new()
            {
                { 0, 1 }
            };
        }
        public int NumberOfPaths => _numberOfMatchingPaths;
        private void Lookup(long sum)
        {
            if (_frequencyOfSums.TryGetValue(sum, out int value))
            {
                _numberOfMatchingPaths += value;
            }
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
            Lookup(currentPathSum - _targetSum);
            Add(currentPathSum);
            TraverseMemoized(node.left, currentPathSum);
            TraverseMemoized(node.right, currentPathSum);
            Remove(currentPathSum);
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
