namespace LeetCodeSolutions;
public class CountGoodNodesInBinaryTreeSolution
{
    private int NumberOfGoodNodes(TreeNode node, int currentPathMaximum)
    {
        if (node == null)
        {
            return 0;
        }

        if (node.val >= currentPathMaximum)
        {
            return 1 + NumberOfGoodNodes(node.left, node.val) + NumberOfGoodNodes(node.right, node.val);
        }

        return NumberOfGoodNodes(node.left, currentPathMaximum) + NumberOfGoodNodes(node.right, currentPathMaximum);
    }
    public int GoodNodes(TreeNode root)
    {
        return NumberOfGoodNodes(root, root.val);
    }
}
