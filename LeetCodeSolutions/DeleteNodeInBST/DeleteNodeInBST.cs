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

            TreeNode node = new(value);
            Insert(node);
        }

        private void Insert(TreeNode node)
        {
            if (_root == null)
            {
                _root = node;
                return;
            }

            TreeNode? cur = _root;
            while (true)
            {
                if (node.val < cur.val)
                {
                    if (cur.left == null)
                    {
                        cur.left = node;
                        return;
                    }
                    cur = cur.left;
                    continue;
                }

                if (cur.right == null)
                {
                    cur.right = node;
                    return;
                }
                cur = cur.right;
            }
        }
        public TreeNode? Root => _root;
    }
    public TreeNode? DeleteNode(TreeNode root, int key)
    {
        Tree tree = new(key);
        Stack<TreeNode?> stack = new();
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
