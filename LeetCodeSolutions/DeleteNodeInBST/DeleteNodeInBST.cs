namespace LeetCodeSolutions;
public class DeleteNodeInBSTSolution
{
    private class ValueWrapper(int value)
    {
        private int _value = value;
        public bool Inserted(ref TreeNode? node)
        {
            if (node == null)
            {
                node = new TreeNode(_value);
                return true;
            }

            return false;
        }
    }
    private class Tree(int key)
    {
        private TreeNode? _root = null;
        private readonly int _key = key;

        public void AddToTree(int value)
        {
            if (value == _key)
            {
                return;
            }

            Insert(value);
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
                }
                else
                {
                    nodeInserted = wrapper.Inserted(ref cur.right);
                    cur = cur.right;
                }
            }
        }
        public TreeNode? Root => _root;
    }
    public TreeNode? DeleteNode(TreeNode? root, int key)
    {
        if (root == null)
        {
            return null;
        }

        Tree tree = new(key);
        Stack<TreeNode> stack = new();
        stack.Push(root);
        while (stack.Count > 0)
        {
            TreeNode cur = stack.Pop();
            tree.AddToTree(cur.val);
            if (cur.left != null) stack.Push(cur.left);
            if (cur.right != null) stack.Push(cur.right);
        }

        return tree.Root;
    }
}
