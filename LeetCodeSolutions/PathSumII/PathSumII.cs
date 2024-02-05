using System.Runtime.CompilerServices;

namespace LeetCodeSolutions;
public class PathSumIISolution
{
    private class TreeWrapper
    {
        private TreeNode _node;
        private IList<IList<int>> _paths;
        private IList<int> _current_path;
        public TreeWrapper(TreeNode node)
        {
            _node = node;
            _paths = [];
            _current_path = [];
        }

        public void Traverse() { }

        public IList<IList<int>> Paths => _paths;
    }
    private IList<IList<int>> GetAllPaths(TreeNode node)
    {
        TreeWrapper wrapper = new(node);
        wrapper.Traverse();
        return wrapper.Paths;

    }

    private bool SumsUpToEqual(IList<int> path, int targetSum)
    {
        int sum = 0;
        foreach (int nodeValue in path)
        {
            if (sum > targetSum)
            {
                return false;
            }
            sum += nodeValue;
        }

        return sum == targetSum;
    }
    public IList<IList<int>> PathSum(TreeNode root, int targetSum)
    {
        IList<IList<int>> AllPaths = GetAllPaths(root);
        IList<IList<int>> SummedPaths = [];
        foreach (IList<int> path in AllPaths)
        {
            if (SumsUpToEqual(path, targetSum))
            {
                SummedPaths.Append(path);
            }
        }
        return SummedPaths;
    }
}
