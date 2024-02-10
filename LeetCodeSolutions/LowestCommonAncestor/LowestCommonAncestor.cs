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
            if (IsBaseCase(node)) return node;
            TreeNode? left = LCA(node.left);
            TreeNode? right = LCA(node.right);

            if (left != null && right != null)
            {
                return node;
            }

            return left ?? right;
        }
    }

    public TreeNode? LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
    {
        TreeTraveler tTrav = new TreeTraveler(p, q);
        return tTrav.LCA(root);
    }
}
