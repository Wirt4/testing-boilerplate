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
            bool nodeInserted = InsertedOnLeaf(ref _root, value);
            TreeNode? cur = _root;

            while (cur != null && !nodeInserted)
            {
                if (value < cur.val)
                {
                    nodeInserted = InsertedOnLeaf(ref cur.left, value);
                    cur = cur.left;
                    continue;
                }

                nodeInserted = InsertedOnLeaf(ref cur.right, value);
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
