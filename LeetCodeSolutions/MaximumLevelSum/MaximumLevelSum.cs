namespace LeetCodeSolutions;
public class MaximumLevelSumSolution
{
    private class NodeStack
    {
        private Stack<TreeNode> _currentLevel;
        private Stack<TreeNode> _nextLevel;
        private bool _levelChange;
        public NodeStack(TreeNode root)
        {
            _currentLevel = new();
            _currentLevel.Push(root);
            _nextLevel = new();
            _levelChange = false;
        }

        public bool IsEmpty()
        {
            return _currentLevel.Count == 0;
        }

        public void PushChildren(TreeNode node)
        {
            Push(node.left);
            Push(node.right);
        }

        private void Push(TreeNode? node)
        {
            if (node != null)
            {
                _nextLevel.Push(node);
            }
        }

        public TreeNode Pop()
        {
            _levelChange = false;
            TreeNode cur = _currentLevel.Pop();

            if (IsEmpty())
            {
                _currentLevel = _nextLevel;
                _levelChange = true;

            }
            return cur;
        }

        public bool HasChangedLevel => _levelChange;
    }

    private class RowSum(int row)
    {
        private readonly int _level = row;
        private int _sum = 0;

        public void Add(int amount)
        {
            _sum += amount;
        }

        public int Level => _level;
        public int Sum => _sum;
    }
    private class RowSums
    {
        private RowSum _highest;
        private RowSum _current;

        public RowSums()
        {
            _current = new(1);
            _highest = _current;
        }

        public void Add(int nodeVal)
        {
            _current.Add(nodeVal);
        }

        public void UpdateHighest()
        {
            if (_current.Sum > _highest.Sum)
            {
                _highest = _current;
            }

            _current = new(_current.Level + 1);
        }

        public int HighestLevel => _highest.Level;
    }
    public int MaxLevelSum(TreeNode root)
    {

        RowSums sums = new();
        NodeStack nodeStack = new(root);

        while (!nodeStack.IsEmpty())
        {
            TreeNode current = nodeStack.Pop();
            sums.Add(current.val);

            if (nodeStack.HasChangedLevel)
            {
                sums.UpdateHighest();
            }

            nodeStack.PushChildren(current);
        }

        return sums.HighestLevel;
    }
}
