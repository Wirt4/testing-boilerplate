namespace LeetCodeSolutions;
public class DeleteNodeInBSTSolution
{
    private class ValueWrapper(int value)
    {
        private readonly int _value = value;
        public bool Inserted(ref TreeNode? node)
        {
            if (node != null) return false;

            node = new TreeNode(_value);
            return true;
        }
    }
    private class Tree(int key)
    {
        private TreeNode? _root = null;
        private readonly int _key = key;

        public void AddToTree(int value)
        {
            if (value != _key) Insert(value);
        }

        private void Insert(int value)
        {
            ValueWrapper wrapper = new(value);
            bool nodeInserted = wrapper.Inserted(ref _root);
            TreeNode? cur = _root;

            while (cur != null && !nodeInserted)
            {
                if (value < cur.val)
                {
                    nodeInserted = wrapper.Inserted(ref cur.left);
                    cur = cur.left;
                    continue;
                }

                nodeInserted = wrapper.Inserted(ref cur.right);
                cur = cur.right;
            }
        }
        public TreeNode? Root => _root;
    }

    private class StackWrapper
    {
        private Stack<TreeNode> stack;
        public StackWrapper(TreeNode root)
        {
            stack = new();
            stack.Push(root);
        }

        public void PushIfValid(TreeNode? node)
        {
            if (node != null) stack.Push(node);
        }

        public TreeNode Pop()
        {
            return stack.Pop();
        }

        public int Count => stack.Count;
    }
    public TreeNode? DeleteNode(TreeNode? root, int key)
    {
        if (root == null) return null;

        Tree tree = new(key);
        StackWrapper stack = new(root);

        while (stack.Count > 0)
        {
            TreeNode cur = stack.Pop();
            tree.AddToTree(cur.val);
            stack.PushIfValid(cur.left);
            stack.PushIfValid(cur.right);
        }

        return tree.Root;
    }
}
