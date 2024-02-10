namespace LeetCodeSolutions;
public class LongestZigZagPathSolution
{
    private class Lengths(int l = 0, int r = 0)
    {
        public int left = l;
        public int right = r;

        public int MaxLength()
        {
            return Math.Max(left, right);
        }
    }

    private int LongestZigZag_R(TreeNode node, Lengths lengths)
    {
        if (node != null)
        {
            lengths.left = LongestZigZag_R(node.left, new(lengths.left + 1, 0));
            lengths.right = LongestZigZag_R(node.right, new(0, lengths.right + 1));
        }
        return lengths.MaxLength();
    }
    public int LongestZigZag(TreeNode root)
    {
        return LongestZigZag_R(root, new());
    }
}
