namespace LeetCodeSolutions;
public class SearchInBinaryTreeSolution
{
    public TreeNode? SearchBST(TreeNode root, int val)
    {
        Stack<TreeNode> stack = new();
        TreeNode cur;
        stack.Push(root);
        while (stack.Count > 0)
        {
            cur = stack.Pop();
            if (cur.val == val)
            {
                return cur;
            }
            if (cur.left != null) stack.Push(cur.left);
        }
        return null;
    }
}
