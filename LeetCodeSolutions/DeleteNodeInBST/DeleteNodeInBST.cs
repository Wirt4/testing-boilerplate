namespace LeetCodeSolutions;
public class DeleteNodeInBSTSolution
{

    public TreeNode? DeleteNode(TreeNode root, int key)
    {
        root.left = null;
        return root;

    }
}
