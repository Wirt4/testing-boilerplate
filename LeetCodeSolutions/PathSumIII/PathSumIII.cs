namespace LeetCodeSolutions;
public class PathSumIIISolution
{
    private static bool IsAtEnd(TreeNode node)
    {
        return node.left == null && node.right == null;
    }

    private void RemoveLastElement(ref List<int> path)
    {
        path.RemoveAt(path.Count - 1);
    }

    private int NumberOfSums(IList<int> path, int targetSum)
    {
        int sums = 0;
        for (int i = 0; i < path.Count; i++)
        {
            int currentSum = 0;
            for (int j = i; j < path.Count; j++)
            {
                currentSum += path[j];
                if (currentSum == targetSum)
                {
                    sums++;
                }
            }
        }
        return sums;
    }
    private void GetAllPaths(TreeNode node, List<int> currentPath, IList<IList<int>> result)
    {
        if (node == null)
        {
            return;
        }

        currentPath.Add(node.val);

        if (IsAtEnd(node))
        {
            result.Add(new List<int>(currentPath));
            RemoveLastElement(ref currentPath);
            return;
        }

        GetAllPaths(node.left, currentPath, result);
        GetAllPaths(node.right, currentPath, result);
        RemoveLastElement(ref currentPath);
    }
    public int PathSum(TreeNode root, int targetSum)
    {
        IList<IList<int>> allPaths = [];
        GetAllPaths(root, [], allPaths);
        int sums = 0;
        foreach (IList<int> path in allPaths)
        {
            sums += NumberOfSums(path, targetSum);
        }
        return sums;
    }
}
