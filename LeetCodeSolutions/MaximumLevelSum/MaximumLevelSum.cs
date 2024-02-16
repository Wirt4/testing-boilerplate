namespace LeetCodeSolutions;
public class MaximumLevelSumSolution
{
    private class LevelSum
    {
        public LevelSum(int value = 0)
        {
            Level = 1;
            Sum = value;
        }

        public int Level;
        public int Sum;

        public void AdvanceToNextLevel()
        {
            Level++;
            Sum = 0;
        }

        public bool IsLessThan(LevelSum externalSum)
        {
            return Sum < externalSum.Sum;
        }

        public void UpdateTo(LevelSum externalSum)
        {
            Level = externalSum.Level;
            Sum = externalSum.Sum;
        }
    }

    private class NodeStack
    {
        private Stack<TreeNode> _stack;
        public NodeStack()
        {
            _stack = new();
        }

        public bool IsEmpty()
        {
            return _stack.Count == 0;
        }

        public void Push(TreeNode? node)
        {
            if (node != null)
            {
                _stack.Push(node);
            }
        }

        public void PushChildren(TreeNode node)
        {
            Push(node.left);
            Push(node.right);
        }

        public TreeNode Pop()
        {
            return _stack.Pop();
        }
    }

    private class LevelSums
    {
        private LevelSum _highest;
        private LevelSum _current;
        public LevelSums(int rootValue)
        {
            _highest = new(rootValue);
            _current = new();
        }
        public void Add(int value)
        {
            _current.Sum += value;
        }

        public void UpdateHighest()
        {
            if (_highest.IsLessThan(_current))
            {
                _highest.UpdateTo(_current);
            }

            _current.AdvanceToNextLevel();
        }

        public int HighestSumLevel => _highest.Level;
    }

    private class StackPair
    {
        private NodeStack _current;
        private NodeStack _next;
        public StackPair(TreeNode root)
        {
            _current = new();
            _current.Push(root);
            _next = new();
        }

        public bool IsEmpty()
        {
            return _current.IsEmpty() && _next.IsEmpty();
        }

        public int GetNextValue()
        {
            TreeNode n = _current.Pop();
            _next.PushChildren(n);
            return n.val;
        }

        public bool HasTraversedLevel()
        {
            return _current.IsEmpty();
        }

        public void UpdateLevel()
        {
            _current = _next;
            _next = new();
        }
    }
    public int MaxLevelSum(TreeNode root)
    {
        LevelSums levelSums = new(root.val);
        StackPair stacks = new(root);

        while (!stacks.IsEmpty())
        {
            levelSums.Add(stacks.GetNextValue());

            if (stacks.HasTraversedLevel())
            {
                levelSums.UpdateHighest();//tiers.advanceToNextLevel
                stacks.UpdateLevel();
            }
        }

        return levelSums.HighestSumLevel;
    }
}
