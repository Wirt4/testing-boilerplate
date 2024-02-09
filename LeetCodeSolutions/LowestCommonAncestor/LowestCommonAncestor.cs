namespace LeetCodeSolutions;
public class LowestCommonAncestorSolution
{

    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
    {
        if (root == null || root.val == p.val || root.val == q.val)
        {
            return root;
        }

        TreeNode leftQuery = LowestCommonAncestor(root.left, p, q);
        TreeNode rightQuery = LowestCommonAncestor(root.right, p, q);

        if (leftQuery == null)
        {
            return rightQuery;
        }

        if (rightQuery == null)
        {
            return leftQuery;
        }

        return root;
    }
}
