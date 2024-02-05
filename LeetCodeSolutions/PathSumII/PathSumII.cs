
namespace LeetCodeSolutions
{
    public class PathSumIISolution
    {
        private void GetAllPaths(TreeNode? node, int targetSum, List<int> currentPath, IList<IList<int>> result)
        {
            if (node == null)
            {
                return;
            }

            currentPath.Add(node.val);

            if (node.left == null && node.right == null && node.val == targetSum)
            {
                result.Add(new List<int>(currentPath));
            }
            else
            {
                GetAllPaths(node.left, targetSum - node.val, currentPath, result);
                GetAllPaths(node.right, targetSum - node.val, currentPath, result);
            }

            currentPath.RemoveAt(currentPath.Count - 1);
        }

        public IList<IList<int>> PathSum(TreeNode root, int targetSum)
        {
            IList<IList<int>> result = [];
            GetAllPaths(root, targetSum, [], result);
            return result;
        }
    }
}