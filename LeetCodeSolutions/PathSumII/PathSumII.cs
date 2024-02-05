
namespace LeetCodeSolutions;
public class PathSumIISolution
{
    private List<List<int>> InsertValueToAll(int value, List<List<int>> paths)
    {
        foreach (List<int> path in paths)
        {
            path.Insert(0, value);
        }
        return paths;
    }

    private bool IsNull(TreeNode? node)
    {
        return node == null;
    }

    private bool IsLastNodeInPath(TreeNode node)
    {
        return IsNull(node.left) && IsNull(node.right);
    }
    private List<List<int>> GetAllPaths(TreeNode? node)
    {
        if (IsNull(node))
        {
            return [];
        }

        if (IsLastNodeInPath(node))
        {
            return [[node.val]];
        }

        List<List<int>> paths = GetAllPaths(node.left);
        paths.AddRange(GetAllPaths(node.right));
        return InsertValueToAll(node.val, paths);
    }
    public IList<IList<int>> PathSum(TreeNode root, int targetSum)
    {
        List<List<int>> allPaths = GetAllPaths(root);
        IList<IList<int>> sums = [];

        foreach (List<int> path in allPaths)
        {
            if (path.Sum() == targetSum)
            {
                sums.Add(path);
            }
        }

        return sums;
    }
}
