namespace LeetCodeSolutions;
public class LeafSimilarTreesSolution
{
    private class TreeWrapper(TreeNode node)
    {
        private readonly List<int> treeLeaves = new();
        private readonly TreeNode current = node;

        public void GetValueSequence()
        {
            PopulateTreeLeaves(current);

        }

        private void PopulateTreeLeaves(TreeNode node)
        {
            if (node.left == null && node.right == null)
            {
                treeLeaves.Add(node.val);
                return;
            }

            if (node.left != null)
            {
                PopulateTreeLeaves(node.left);
            }

            if (node.right != null)
            {
                PopulateTreeLeaves(node.right);
            }
        }

        public List<int> TreeLeaves => treeLeaves;
    }
    private int[] GetValueSequence(TreeNode node)
    {
        TreeWrapper wrapper = new TreeWrapper(node);
        wrapper.GetValueSequence();
        return wrapper.TreeLeaves.ToArray();
    }
    public bool LeafSimilar(TreeNode root1, TreeNode root2)
    {
        int[] root1ValueSequence = GetValueSequence(root1);
        int[] root2ValueSequence = GetValueSequence(root2);

        if (root1ValueSequence.Length != root2ValueSequence.Length)
        {
            return false;
        }

        return root1ValueSequence.SequenceEqual(root2ValueSequence);
    }
}
