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

        private static bool InsertedOnLeaf(ref TreeNode? node, int value)
        {
            if (node == null)
            {
                node = new TreeNode(value);
                return true;
            }

            return false;
        }


        private void Insert(int value)
        {
            if (_root == null)
            {
                _root = new TreeNode(value);
                return;
            }

            TreeNode? cur = _root;
            while (cur != null)
            {
                if (value < cur.val)
                {
                    if (InsertedOnLeaf(ref cur.left, value)) return;
                    cur = cur.left;
                    continue;
                }

                if (InsertedOnLeaf(ref cur.right, value)) return;
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
