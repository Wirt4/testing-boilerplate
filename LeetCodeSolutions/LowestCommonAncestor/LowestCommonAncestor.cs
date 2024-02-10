namespace LeetCodeSolutions;
public class LowestCommonAncestorSolution
{
    private class TreeTraveler(TreeNode matchNodeP, TreeNode matchNodeQ)
    {
        private readonly int p_value = matchNodeP.val;
        private readonly int q_value = matchNodeQ.val;

        private bool IsBaseCase(TreeNode? node) { return node == null || node.val == p_value || node.val == q_value; }

        public TreeNode? LowestCommonAncestor(TreeNode? node)
        {
            if (IsBaseCase(node)) return node;

            TreeNode? left = LowestCommonAncestor(node.left);
            TreeNode? right = LowestCommonAncestor(node.right);

            if (left != null && right != null) return node;

            return left ?? right;
        }
    }

    public TreeNode? LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
    {
        TreeTraveler treeTraveler = new(p, q);
        return treeTraveler.LowestCommonAncestor(root);
    }
}
