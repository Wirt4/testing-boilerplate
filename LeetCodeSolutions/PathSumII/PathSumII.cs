
namespace LeetCodeSolutions
{
    public class PathSumIISolution
    {
        private static bool IsAtEndAndHitTarget(TreeNode node, int targetSum)
        {
            return node.left == null && node.right == null && node.val == targetSum;
        }

        private void RemoveLastElement(ref List<int> path)
        {
            path.RemoveAt(path.Count - 1);
        }
        private void GetAllPaths(TreeNode? node, int targetSum, List<int> currentPath, IList<IList<int>> result)
        {
            if (node == null)
            {
                return;
            }

            currentPath.Add(node.val);

            if (IsAtEndAndHitTarget(node, targetSum))
            {
                result.Add(new List<int>(currentPath));
                RemoveLastElement(ref currentPath);
                return;
            }

            int adjustedSum = targetSum - node.val;
            GetAllPaths(node.left, adjustedSum, currentPath, result);
            GetAllPaths(node.right, adjustedSum, currentPath, result);
            RemoveLastElement(ref currentPath);
        }

        public IList<IList<int>> PathSum(TreeNode root, int targetSum)
        {
            IList<IList<int>> result = [];
            GetAllPaths(root, targetSum, [], result);
            return result;
        }
    }
}