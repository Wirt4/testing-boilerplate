

namespace LeetCodeSolutions;
public class LowestCommonAncestorSolution
{

    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
    {
        if (p.val > q.val)
        {
            TreeNode temp = p;
            p = q;
            q = temp;
        }

        if (root.val == p.val || root.val == q.val)
        {
            return root;
        }

        if (root.val > p.val && root.val < q.val)
        {
            return root;
        }

        if (root.val < p.val)
        {
            return LowestCommonAncestor(root.left, p, q);
        }

        if (root.val > q.val)
        {
            return LowestCommonAncestor(root.right, p, q);
        }

        return null;
    }
}
