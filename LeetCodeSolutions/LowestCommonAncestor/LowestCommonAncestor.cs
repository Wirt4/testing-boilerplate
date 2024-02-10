namespace LeetCodeSolutions;
public class LowestCommonAncestorSolution
{
    private class TreeTraveler(TreeNode p, TreeNode q)
    {
        private readonly int p_value = p.val;
        private readonly int q_value = q.val;

        private bool IsBaseCase(TreeNode? node)
        {
            return node == null || node.val == p_value || node.val == q_value;
        }
        public TreeNode? LCA(TreeNode? node)
        {
            if (IsBaseCase(node))
            {
                return node;
            }
            TreeNode? leftQuery = LCA(node.left);
            TreeNode? rightQuery = LCA(node.right);
            if (leftQuery == null)
            {
                return rightQuery;
            }
            if (rightQuery == null)
            {
                return leftQuery;
            }
            return node;
        }
    }

    public TreeNode? LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
    {
        TreeTraveler tTrav = new TreeTraveler(p, q);
        return tTrav.LCA(root);
    }
}
