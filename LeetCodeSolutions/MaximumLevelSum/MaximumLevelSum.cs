namespace LeetCodeSolutions;
public class MaximumLevelSumSolution
{
    public int MaxLevelSum(TreeNode root)
    {
        Stack<TreeNode> nodeStack = new();
        nodeStack.Push(root);
        int highest = root.val;
        while (nodeStack.Count > 0)
        {
            TreeNode current = nodeStack.Pop();
            if (current.left != null)
            {
                nodeStack.Push(current.left);
            }
            if (current.right != null)
            {
                nodeStack.Push(current.right);
            }
            highest = highest > current.val ? highest : current.val;
        }
        return highest;
    }
}
