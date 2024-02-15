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

    private class RowSums
    {
        private int _highestSum;
        private int _currentSum;
        private bool _onfirstTier;
        private int _highestLevel;
        private int _currentLevel;

        public RowSums()
        {
            _currentSum = 0;
            _highestSum = _currentSum;
            _onfirstTier = true;
            _highestLevel = 1;
            _currentLevel = 1;
        }

        public void Add(int nodeVal)
        {
            _currentSum += nodeVal;
        }

        public void UpdateHighest()
        {
            if (_onfirstTier || _currentSum > _highestSum)
            {
                _highestSum = _currentSum;
                _onfirstTier = false;
                _highestLevel = _currentLevel;
            }
            _currentSum = 0;
            _currentLevel++;
        }

        public int HighestLevel => _highestLevel;
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
