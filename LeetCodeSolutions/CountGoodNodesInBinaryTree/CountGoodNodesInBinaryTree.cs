namespace LeetCodeSolutions;
public class CountGoodNodesInBinaryTreeSolution
{
    private int RecursiveSumCall(TreeNode node, int maximum)
    {
        return NumberOfGoodNodes(node.left, maximum) + NumberOfGoodNodes(node.right, maximum);
    }
    private int NumberOfGoodNodes(TreeNode node, int currentPathMaximum)
    {
        if (node == null)
        {
            return 0;
        }

        if (node.val >= currentPathMaximum)
        {
            return 1 + RecursiveSumCall(node, node.val);
        }

        return RecursiveSumCall(node, currentPathMaximum);
    }
    public int GoodNodes(TreeNode root)
    {
        return NumberOfGoodNodes(root, root.val);
    }
}
