

using System.ComponentModel.Design.Serialization;

namespace LeetCodeSolutions;
public class LowestCommonAncestorSolution
{

    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
    {
        if (p.val > q.val)
        {
            (q, p) = (p, q);
        }

        while (root.val != p.val && root.val != q.val && (root.val < p.val || root.val > q.val))
        {
            if (root.val < p.val)
            {
                root = root.left;
                continue;
            }
            root = root.right;
        }

        return root;
    }
}
