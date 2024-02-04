namespace LeetCodeSolutions;
public class CountGoodNodesInBinaryTreeSolution
{
    private int NumberOfNodesLessThanRootValue(TreeNode node, int rootValue)
    {
        if (node == null)
        {
            return 0;
        }

        int sum = node.val <= rootValue ? 1 : 0;
        int leftSum = NumberOfNodesLessThanRootValue(node.left, rootValue);
        int rightSum = NumberOfNodesLessThanRootValue(node.right, rootValue);
        return sum + leftSum + rightSum;
    }
    public int GoodNodes(TreeNode root)
    {
        if (root == null)
        {
            return 0;
        }

        int rootValue = root.val;
        return NumberOfNodesLessThanRootValue(root, rootValue);
    }
}
