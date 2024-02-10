namespace LeetCodeSolutions;
public class LowestCommonAncestorSolution
{
    private class TreeTraveler
    {
        private TreeNode _p;
        private TreeNode _q;
        public TreeTraveler(TreeNode p, TreeNode q)
        {
            _p = p;
            _q = q;
        }

        private bool IsBaseCase(TreeNode? node)
        {
            return node == null || node.val == _p.val || node.val == _q.val;
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
