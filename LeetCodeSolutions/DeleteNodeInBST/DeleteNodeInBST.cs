namespace LeetCodeSolutions;
public class DeleteNodeInBSTSolution
{
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


        private class Foo(int value)
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

        private void Insert(int value)
        {
            Foo foo = new(value);
            bool nodeInserted = foo.Inserted(ref _root);
            TreeNode? cur = _root;

            while (cur != null && !nodeInserted)
            {
                if (value < cur.val)
                {
                    nodeInserted = foo.Inserted(ref cur.left);
                    cur = cur.left;
                }
                else
                {
                    nodeInserted = foo.Inserted(ref cur.right);
                    cur = cur.right;
                }
            }
        }
        public TreeNode? Root => _root;
    }
    public TreeNode? DeleteNode(TreeNode root, int key)
    {
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
