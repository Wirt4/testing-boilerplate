namespace LeetCodeSolutions;
public class PathSumIIISolution
{
    private class TreeSearcher
    {
        private int _numPaths;
        public TreeSearcher()
        {
            _numPaths = 0;
        }
        public int NumberOfPaths => _numPaths;
        private void TestAsRoot(TreeNode node, int targetSum)
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
            TestAsRoot(node.left, adjustedSum);
            TestAsRoot(node.right, adjustedSum);
        }
        public void DepthFirstSearch(TreeNode node, int targetSum)
        {
            if (node == null)
            {
                return;
            }

            TestAsRoot(node, targetSum);
            DepthFirstSearch(node.left, targetSum);
            DepthFirstSearch(node.right, targetSum);
        }
    }
    public int PathSum(TreeNode root, int targetSum)
    {
        TreeSearcher searchWrapper = new();
        searchWrapper.DepthFirstSearch(root, targetSum);
        return searchWrapper.NumberOfPaths;
    }
}
