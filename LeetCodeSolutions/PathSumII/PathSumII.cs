
using System.Collections;

namespace LeetCodeSolutions;
public class PathSumIISolution
{
    private List<List<int>> GetAllPaths(TreeNode? node)
    {
        //base cases
        if (node == null)
        {
            return [];
        }

        if (node.left == null && node.right == null)
        {
            //returning a path of one
            return [[node.val]];
        }

        List<List<int>> leftPaths = GetAllPaths(node.left);
        List<List<int>> rightPaths = GetAllPaths(node.right);
        leftPaths.AddRange(rightPaths);
        List<List<int>> allPaths = leftPaths;

        foreach (List<int> path in allPaths)
        {
            path.Insert(0, node.val);
        }

        return allPaths;


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
