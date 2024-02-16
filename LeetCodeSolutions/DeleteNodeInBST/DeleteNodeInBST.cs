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

            Insert(ref _root, node);
        }

        private static void Insert(ref TreeNode? root, TreeNode node)
        {
            if (root == null)
            {
                root = node;
                return;
            }
            if (node.val < root.val)
            {
                if (root.left == null)
                {
                    root.left = node;
                    return;
                }
                Insert(ref root.left, node);
            }

            if (root.right == null)
            {
                root.right = node;
                return;
            }

            Insert(ref root.right, node);

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
            if (cur.right != null) stack.Push(cur.right);
            if (cur.left != null) stack.Push(cur.left);
        }

        return tree.Root;

    }
}
