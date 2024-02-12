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

        public Lengths ShiftLeft()
        {
            return new Lengths(left + 1, 0);
        }

        public Lengths ShiftRight()
        {
            return new Lengths(0, right + 1);
        }
    }

    private static int LongestZigZag_R(TreeNode node, Lengths lengths)
    {
        if (node != null)
        {
            lengths.left = LongestZigZag_R(node.left, lengths.ShiftLeft());
            lengths.right = LongestZigZag_R(node.right, lengths.ShiftRight());
        }

        return lengths.MaxLength();
    }
    public int LongestZigZag(TreeNode root)
    {
        Lengths lengthsOfZero = new();
        int ans = LongestZigZag_R(root, lengthsOfZero);

        return 3;
    }
}
