namespace LeetCodeSolutions;
public class MaximumLevelSumSolution
{
    private class NodeStack
    {
        private Stack<TreeNode> _stack;
        public NodeStack(TreeNode root)
        {
            _stack = new();
            _stack.Push(root);
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

        public TreeNode Pop()
        {
            return _stack.Pop();
        }
    }
    public int MaxLevelSum(TreeNode root)
    {

        int highest = root.val;
        NodeStack nodeStack = new(root);
        while (!nodeStack.IsEmpty())
        {
            TreeNode current = nodeStack.Pop();
            nodeStack.Push(current.left);
            nodeStack.Push(current.right);
            highest = highest > current.val ? highest : current.val;
        }
        return highest;
    }
}
