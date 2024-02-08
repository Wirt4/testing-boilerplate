

namespace LeetCodeSolutions;
public class LowestCommonAncestorSolution
{

    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
    {
        if (p.val > q.val)
        {
            (q, p) = (p, q);
        }

        Stack<TreeNode> nodeStack = new();
        nodeStack.Push(root);

        while (nodeStack.Count > 0)
        {
            TreeNode node = nodeStack.Pop();
            if (node.val == p.val || node.val == q.val)
            {
                return node;
            }
            if (node.val > p.val && node.val < q.val)
            {
                return node;
            }
            if (node.val < p.val)
            {
                nodeStack.Push(node.left);
                continue;
            }

            nodeStack.Push(node.right);
        }

        return null;
    }
}
