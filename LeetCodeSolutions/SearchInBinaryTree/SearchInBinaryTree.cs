namespace LeetCodeSolutions;
public class SearchInBinaryTreeSolution
{
    public TreeNode? SearchBST(TreeNode root, int val)
    {
        if (root.val == val)
        {
            return root;
        }
        return null;
    }
}
