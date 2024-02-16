namespace LeetCodeSolutions;
public class SearchInBinaryTreeSolution
{
    private class TreeNodeStack
    {
        private Stack<TreeNode> _stack;
        public TreeNodeStack(TreeNode root)
        {
            _stack = new();
            _stack.Push(root);
        }

        public int Count => _stack.Count;
        public void Push(TreeNode? node)
        {
            if (node != null)
            {
                _stack.Push(node);
            }
        }

        public TreeNode? Pop()
        {
            if (_stack.TryPop(out TreeNode? result))
            {
                return result;
            }

            return null;
        }
    }

    private enum Comparison
    {
        Equal,
        LessThan,
        GreaterThan,
        Default
    }

    private Comparison Compare(int baseValue, TreeNode? node)
    {
        if (node == null)
        {
            return Comparison.Default;
        }
        if (baseValue == node.val)
        {
            return Comparison.Equal;
        }

        if (baseValue < node.val)
        {
            return Comparison.LessThan;
        }

        return Comparison.GreaterThan;
    }
    public TreeNode? SearchBST(TreeNode root, int val)
    {
        TreeNodeStack stack = new(root);

        while (true)
        {
            TreeNode? cur = stack.Pop();
            switch (Compare(val, cur))
            {
                case Comparison.Equal:
                case Comparison.Default:
                    return cur;
                case Comparison.LessThan:
                    stack.Push(cur?.left);
                    break;
                case Comparison.GreaterThan:
                    stack.Push(cur?.right);
                    break;
            }
        }
    }
}
