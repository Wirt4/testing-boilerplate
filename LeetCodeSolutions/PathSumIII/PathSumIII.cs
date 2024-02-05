namespace LeetCodeSolutions;
public class PathSumIIISolution
{
    private class TreeSearcher
    {
        private int _numPaths;
        private Dictionary<int, int> _cache;
        public TreeSearcher()
        {
            _numPaths = 0;
            _cache = new()
            {
                { 0, 1 }
            };
        }
        public int NumberOfPaths => _numPaths;
        private void SearchForSum(TreeNode node, int targetSum)
        {
            if (node == null)
            {
                return;
            }

            if (node.val == targetSum)
            {
                _numPaths++;
            }

            int adjustedSum = targetSum - node.val;
            SearchForSum(node.left, adjustedSum);
            SearchForSum(node.right, adjustedSum);
        }
        private void _TraverseMemoized(TreeNode node, int targetSum, int currentPathSum)
        {
            if (node == null)
            {
                return;
            }
            currentPathSum += node.val;
            int oldPathSum = currentPathSum - targetSum;
            if (_cache.ContainsKey(oldPathSum))
            {
                _numPaths += _cache[oldPathSum];
            }

            if (_cache.ContainsKey(currentPathSum))
            {
                _cache[currentPathSum]++;
            }
            else
            {
                _cache.Add(currentPathSum, 1);
            }

            _TraverseMemoized(node.left, targetSum, currentPathSum);
            _TraverseMemoized(node.right, targetSum, currentPathSum);

            _cache[currentPathSum]--;
        }
        public void TraverseTree(TreeNode node, int targetSum)
        {
            if (node == null)
            {
                return;
            }

            SearchForSum(node, targetSum);
            TraverseTree(node.left, targetSum);
            TraverseTree(node.right, targetSum);
        }
    }
    public int PathSum(TreeNode root, int targetSum)
    {
        TreeSearcher searchWrapper = new();
        searchWrapper.TraverseTree(root, targetSum);
        return searchWrapper.NumberOfPaths;
    }
}
